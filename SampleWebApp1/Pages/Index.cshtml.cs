using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleWebApp1.Model;

namespace SampleWebApp1.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public Person Person { get; set;
        }

        public void OnGet()
        {
            
        }
    }
}
