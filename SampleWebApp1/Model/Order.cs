using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApp1.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        //navigation properties
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
