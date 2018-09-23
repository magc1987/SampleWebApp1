using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                .Include(admission => admission.ItemOrderDetails).ThenInclude(item => item.Supplies).SingleOrDefaultAsync();

            IList<Select2List> results = _context.Supplies
                .Select(s => new Select2List { Id = s.SupplyID, Text = s.SupplyName }).ToList();

            selectListItems = results.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Text }).ToList();

            if (Admission == null)
                return NotFound();


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string t = Admission.Patients.FullName;
            string s = Admission.Patients.LastName;

            return Page();
        }
    }
}