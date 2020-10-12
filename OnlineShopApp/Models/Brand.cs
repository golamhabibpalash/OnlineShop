using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name ="Brand Name"), StringLength(10)]
        public string BrandName { get; set; }

        [Display(Name ="Product Type")]
        public int ProductTypeId { get; set; }

        [Display(Name ="Brand Logo")]
        public byte[] BrandLogo { get; set; }

        public ProductType ProductType { get; set; }
        public ICollection<Product> Products { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
