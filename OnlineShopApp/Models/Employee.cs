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

        [Display(Name ="Gender")]
        public int GenderId { get; set; }

        [Display(Name = "Religion"),StringLength(10)]
        public int ReligionId { get; set; }


        [Display(Name = "Blood Group"),StringLength(5)]
        public int BloodGroupId { get; set; }

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

        [Display(Name = "Marital Status")]///বৈবাহিক অবস্থা
        public int  MaritalStatusId { get; set; }

        [Display(Name = "Bank Account")]
        public string BankAccount { get; set; }

        public Gender Gender { get; set; }
        public Religion Religion { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
