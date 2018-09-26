using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleWebApp1.Model
{
    public class Admission
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdmissionId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Admission Date")]
        public DateTime AdmissionDate { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime LastModified { get; set; }

        //navigation properties
        public int PatientId { get; set; }
        public Patient Patients { get; set; }

        public IList<ItemOrderDetail> ItemOrderDetails { get; set; }
        
    }
}
