﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace SampleWebApp1.Model
{
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        
        [Required(ErrorMessage ="Please Input a First Name"), Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please Input a Last Name"), Display(Name ="Last Name")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Please Input a Birth Date"), DisplayFormat(DataFormatString ="{0:MM-DD-YYYY}", ApplyFormatInEditMode =true)]
        public DateTime BirthDate { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0}, {1} {2}", LastName, FirstName, MiddleName);
            }
        }

        public int Age
        {
            get
            {
                DateTime dateNow = DateTime.Now.Date;
                int _age = 0;
                if (dateNow.Month < dateNow.Month)
                    _age += 1;
                if (dateNow.Year > BirthDate.Year)
                    _age += dateNow.Year - BirthDate.Year;
                return _age;
            }
        }


        public IEnumerable<Order> Orders { get; set; }

    }
}
