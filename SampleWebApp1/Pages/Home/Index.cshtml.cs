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
    public class IndexModel : PageModel
    {
        private readonly SampleWebApp1.Data.SampleContext _context;

        public IndexModel(SampleWebApp1.Data.SampleContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patients.ToListAsync();
        }
    }
}
