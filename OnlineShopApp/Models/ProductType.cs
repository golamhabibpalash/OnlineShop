using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        [Display(Name ="Category Name"),StringLength(10)]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public byte[] CategoryImage { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Product> Products { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
