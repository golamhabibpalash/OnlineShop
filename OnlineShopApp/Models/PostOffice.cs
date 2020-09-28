using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class PostOffice
    {

        public int Id { get; set; }
        public int ThanaOrUpazilaId { get; set; }

        public string Name { get; set; }
        public int PostCode { get; set; }

        public ThanaOrUpazila ThanaOrUpazila { get; set; }



        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
