using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceTrackerWebApp.Models
{
    public class FinanceModel
    {
        public decimal Income { get; set; }

        [Display (Name = "Tax Deduction")]
        public decimal TaxDeduction { get; set; }

        public decimal Groceries { get; set; }
        public decimal Utilities { get; set; }
        public decimal Travel { get; set; }
        public decimal Phone { get; set; }
        public decimal Other { get; set; }
        public decimal House { get; set; }
        public decimal Vehicle { get; set; }

        [Display (Name = "Buy House")]
        public bool BuyHouse { get; set; }

        [Display (Name = "Buy Vehicle")]
        public bool BuyVehicle { get; set; }

        public decimal AvailableMoney { get; set; }
    }
}