﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }

        [Required, StringLength(10)]
        public string UserName { get; set; }
        public string Password { get; set; }

        [Display(Name="Gender")]
        public int GenderId { get; set; }

        [Range(01300000000, 01999999999)]
        public int PhoneNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Image { get; set; }

        public int? NID { get; set; }
        public string NIDScan { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Order> Orders { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
