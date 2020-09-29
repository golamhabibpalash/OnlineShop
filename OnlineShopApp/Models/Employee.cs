using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenderId { get; set; }

        [Display(Name ="Father's Name")]
        public string FatherName { get; set; }

        [Display(Name ="Mother's Name")]
        public string MotherName { get; set; }
        
        [Range(01300000000,01999999999)]
        public int PhoneNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public int NID { get; set; }
        public string NIDScan { get; set; }

        public Gender Gender { get; set; }


    }
}
