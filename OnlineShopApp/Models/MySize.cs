using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class MySize
    {
        public int Id { get; set; }

        [Required, StringLength(20), Display(Name ="Size")]
        public string SizeName { get; set; }

        public string ShortName { get; set; }

    }
}
