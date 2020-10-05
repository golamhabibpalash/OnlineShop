using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class MaritalStatus
    {
        public int Id { get; set; }

        [Display(Name = "Marital Status")]
        public string MStatus { get; set; }
    }
}
