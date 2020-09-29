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

        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }

        public byte[] BrandLogo { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
