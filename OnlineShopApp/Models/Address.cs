using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaOrUpazilaId { get; set; }
        public int PostOfficeId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public string MyAddress { get; set; }
        public int SupplierId { get; set; }

        public Division Division { get; set; }
        public District District { get; set; }
        public ThanaOrUpazila ThanaOrUpazila { get; set; }
        public PostOffice PostOffice { get; set; }

        //Type 1=PresentAddress Type 2=Permanent Address
        public int Type { get; set; }
    }
}
