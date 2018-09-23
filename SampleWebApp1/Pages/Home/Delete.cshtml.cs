using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleWebApp1.Data;
using SampleWebApp1.Model;

namespace SampleWebApp1.Pages.Home
{
    public class DeleteModel : PageModel
    {
        private readonly SampleWebApp1.Data.SampleContext _context;

        public DeleteModel(SampleWebApp1.Data.SampleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        [BindProperty]
        public List<Admission> Admissions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients.Where(m => Patient.PatientId == id).Include(z => z.Admissions).FirstOrDefaultAsync();

            if (Patient == null)
            {
                return NotFound();
            }
           
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients.FindAsync(id);

            if (Patient != null)
            {
                _context.Patients.Remove(Patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
