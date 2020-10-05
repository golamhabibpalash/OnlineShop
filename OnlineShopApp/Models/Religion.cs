using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Religion
    {
        public int Id { get; set; }

        [Display(Name = "Religion"), StringLength(10)]
        public string ReligionName { get; set; }
    }
}
