using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApp1.Model
{
    public class ItemOrderDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailID { get; set; }

        public int OrderQuantity { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime LastModified { get; set; }

        public int Position { get; set; }

        //navigation property
        public int AdmissionId { get; set; }
        public Admission Admissions { get; set; }

        public int SupplyID { get; set; }
        public Supply Supplies { get; set; }
    }
}
