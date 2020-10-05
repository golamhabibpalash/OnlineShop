using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class MyColor
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string ColorName { get; set; }
    }
}
