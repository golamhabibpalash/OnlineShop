﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Display(Name = "Gender Name"),StringLength(10)]
        public string GenderName { get; set; }
    }
}
