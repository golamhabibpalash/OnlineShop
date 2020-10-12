using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Display(Name="Division")]
        public int DivisionId { get; set; }

        [Display(Name ="District")]
        public int DistrictId { get; set; }

        [Display(Name ="Thana/Upazilla")]
        public int ThanaOrUpazilaId { get; set; }

        [Display(Name ="Post Office")]
        public int PostOfficeId { get; set; }


        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Display(Name ="Customer")]
        public int CustomerId { get; set; }


        [Display(Name = "Address"), StringLength(255)]
        public string MyAddress { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public Division Division { get; set; }
        public District District { get; set; }
        public ThanaOrUpazila ThanaOrUpazila { get; set; }
        public PostOffice PostOffice { get; set; }

        //Type 1/true=PresentAddress Type 0/false=Permanent Address
        [Range(1,2), Display(Name ="Type(1 for Present 2 For Permanent)")]
        public int AddressType { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
