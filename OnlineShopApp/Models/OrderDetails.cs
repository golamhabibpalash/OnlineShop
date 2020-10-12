using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Display(Name ="Order No")]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public Order Order { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
