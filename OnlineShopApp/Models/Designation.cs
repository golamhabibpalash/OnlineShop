using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class Designation
    {
        public int Id { get; set; }

        [Display(Name="Designation Name"), StringLength(10)]
        public string Name { get; set; }

        [Display(Name ="Type of Employee")]
        public int EmpTypeId { get; set; }

        [Display(Name = "Grade")]
        public int GradeId { get; set; }

        public Grade Grade { get; set; }
        public EmpType EmpType { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
