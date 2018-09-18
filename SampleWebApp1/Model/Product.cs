using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp1.Model
{
    public class Product
    {
        public int ProductID { get; set; }

        public String ProductDescription { get; set; }

        public double ProductUnitPrice { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
