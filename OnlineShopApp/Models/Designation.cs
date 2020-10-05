using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmpTypeId { get; set; }

        public EmpType EmpType { get; set; }
    }
}
