using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class PayScale
    {
        public int Id { get; set; }

        [Required, Display(Name = "Pay Scale")]
        public string Scale { get; set; }

        [Display(Name = "No. Of Increment")]
        public int NoOfIncrement { get; set; }

        [Display(Name = "Lower Limit")]
        public double LowerLimit { get; set; }

        [Display(Name = "Upper Limit")]
        public double UpperLimit { get; set; }
        public string Grade { get; set; }

        [Display(Name = "Increment Amount")]
        public double IncrementAmount { get; set; }

        [Display(Name = "Fiscal Year")]
        public int FiscalYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public ICollection<Designation> Designation { get; set; }
        public ICollection<PayScaleSalaryHead> PayScaleSalaryHead { get; set; }
    }
}
