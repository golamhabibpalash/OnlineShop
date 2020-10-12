using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class ThanaOrUpazila
    {
        public int Id { get; set; }

        [Display(Name = "District")]
        public int DistrictId { get; set; }

        [Display(Name = "Thana/ Upazilla"), StringLength(15)]
        public string Name { get; set; }

        public District District { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
