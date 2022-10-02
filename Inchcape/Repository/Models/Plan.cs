using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inchcape.Repository.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        [ForeignKey("CarId")]
        public int CarId { get; set;}
        [ForeignKey("FinancialTypeId")]
        public int FinancialTypeId { get; set; }
        public double FirstQuarter { get; set; }
        public double SecondQuarter { get; set; }
        public double ThirdQuarter { get; set; }
        public double AfterThirdQuarter { get; set; }
    }
}

