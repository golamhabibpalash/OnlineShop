using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name ="Unit of Measurments")]
        public string UoM { get; set; }

        [Display(Name ="Unit Price")]
        public int ProductPrice { get; set; }

        [Display(Name = "Product Color")]
        public int MyColorId { get; set; }

        [Display(Name = "Product Size")]
        public int MySizeId { get; set; }
        public int BrandId { get; set; }
        public int ProductTypeId { get; set; }
        public int SupplierId { get; set; }
        public bool IsAvailable { get; set; }

        [Display(Name ="Product Image")]
        public string ProdImage { get; set; }

        public MyColor MyColor { get; set; }
        public MySize MySize { get; set; }
        public ProductType ProductType { get; set; }
        public Brand Brand { get; set; }
        public Supplier Supplier { get; set; }
    }
}
