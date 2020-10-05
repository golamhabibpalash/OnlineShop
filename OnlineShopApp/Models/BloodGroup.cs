using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class BloodGroup
    {
        public int Id { get; set; }

        [Display(Name = "Blood Group"),StringLength(5)]
        public string BloodGroupName { get; set; }

    }
}
