using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp1.Model
{
    public class Select2ListOptions
    {
        public int Total { get; set; }
        public IList<Select2List> results { get; set; }

    }

    public class Select2List
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
