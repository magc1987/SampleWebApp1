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
    public class DetailsModel : PageModel
    {
        private readonly SampleWebApp1.Data.SampleContext _context;

        public DetailsModel(SampleWebApp1.Data.SampleContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients.Where(Patients => Patients.PatientId == id).Include(Patients=>Patients.Admissions)
                .FirstOrDefaultAsync();

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
