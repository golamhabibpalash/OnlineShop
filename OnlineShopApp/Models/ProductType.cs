using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
