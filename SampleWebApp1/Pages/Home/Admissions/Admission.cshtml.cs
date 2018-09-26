using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SampleWebApp1.Data;
using SampleWebApp1.Model;

namespace SampleWebApp1.Pages.Home.Admissions
{
    public class AdmissionModel : PageModel
    {
        private readonly SampleContext _context;

        public AdmissionModel(SampleContext context)
        {
            _context = context;
        }


        public IList<SelectListItem> selectListItems { get; set; }

        [BindProperty]
        public Admission Admission { get; set; }

        [BindProperty]
        public Select2ListOptions Select2ListOptions { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Admission = await _context.Admissions.Where(Admission => Admission.AdmissionId == id)
                .Include(admission => admission.Patients)
                .Include(admission => admission.ItemOrderDetails).ThenInclude(item => item.Supplies)
                .SingleOrDefaultAsync();

            //reorder
            Admission.ItemOrderDetails = Admission.ItemOrderDetails.OrderBy(p => p.Position).ToList();

            IList<Select2List> results = _context.Supplies
                .Select(s => new Select2List { Id = s.SupplyID, Text = s.SupplyName }).ToList();

            selectListItems = results.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Text }).ToList();

            if (Admission == null)
                return NotFound();


            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            //edit position
            int pos = 0;
            foreach (ItemOrderDetail item in Admission.ItemOrderDetails)
            {
                item.Position = pos;
                item.Supplies.SupplyID = item.SupplyID;
                pos++;
            }           
            
            _context.ChangeTracker.TrackGraph(Admission, e =>
            {
                e.Entry.State = EntityState.Unchanged;

                //if entity tracked is admission
                if(e.Entry.Entity is Admission)
                {
                    var track = e.Entry.Entity;
                    var entry1 = _context.Entry(track as Admission);
                    entry1.Property(p => p.AdmissionDate).IsModified = false;

                   
                }

                //if entity tracked is itemorderdetail
                if(e.Entry.Entity is ItemOrderDetail)
                {
                    var trackedEntity = e.Entry.Entity;
                    var entry = _context.Entry(trackedEntity as ItemOrderDetail);
                    entry.Property(f => f.OrderQuantity).IsModified = true;
                    entry.Property(f => f.SupplyID).IsModified = true;
                    entry.Property(f => f.OrderDate).IsModified = true;
                    entry.Property(f => f.Position).IsModified = true;
                }

                //if entity tracked is supply
                if(e.Entry.Entity is Supply)
                {
                }
            });

            /*
            _context.Attach(Admission).State = EntityState.Modified;

            foreach (var entity in Admission.ItemOrderDetails)
            {
                EntityEntry<ItemOrderDetail> entrystate = _context.Attach(entity);
                entrystate.Property(p => p.OrderDate).IsModified = true;
                entrystate.Property(p => p.OrderQuantity).IsModified = true;
                entrystate.Property(p => p.SupplyID).IsModified = true;
            }
            */
            await _context.SaveChangesAsync();
            
            return RedirectToPage("/Home/Admissions/Admission",new { id = id });
        }

        public IActionResult OnPostSend()
        {
            return Page();
        }

        protected bool AdmissionExists(int? id)
        {
            return _context.Admissions.Any(a => a.AdmissionId == id);
        }
    }
}