using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }

        [Display(Name ="Company"),StringLength(20)]
        public string CompanyName { get; set; }

        [Display(Name ="Phone"),Range(01300000000, 01999999999)]
        public int PhoneNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Address Address { get; set; }
        public ICollection<Product> Products { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
