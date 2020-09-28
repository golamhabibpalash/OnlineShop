﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class District
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }

        public string Name { get; set; }

        public ICollection<ThanaOrUpazila> ThanaOrUpazilas { get; set; }

        public Division Division { get; set; }



        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
