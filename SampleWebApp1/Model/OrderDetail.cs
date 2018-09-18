using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp1.Model
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public string OrderDescription { get; set; }

        public int OrderQuantity { get; set; }

        //navigation property
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
