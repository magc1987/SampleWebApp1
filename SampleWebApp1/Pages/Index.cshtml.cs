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
        public Person Person { get; set;}

        [BindProperty(SupportsGet =true)]
        public IList<Person> Persons { get; set; }

        public void OnGet()
        {
            Person[] p = new Person[]
            {
                new Person{FirstName="Butch", LastName="Roque"},
                new Person{ FirstName="Marv", LastName="Chan"},
                new Person{FirstName="Jonas", LastName="Bico"},
                new Person{FirstName="Lennie", LastName="Chua"},
                new Person{FirstName="Alymer", LastName="Hernandez"},
                new Person{FirstName="Joseph", LastName="Ang"},
            };
            Persons = p;
            foreach (var item in Persons)
            {
                
            }
        }

        public void OnPostAsync()
        {
            IList<Person> p = Persons;

        }
    }
}
