using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApp1.Model
{
    public class Supply
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplyID { get; set; }

        public string SupplyName { get; set; }

        public string SupplyDescription { get; set; }

        public double SupplyUnitPrice { get; set; }

        //navigation property
        public IList<ItemOrderDetail> ItemOrderDetails { get; set; }
    }
}
