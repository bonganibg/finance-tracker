using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceTrackerWebApp.Models
{
    public class SavingModel
    {

        public int SavingID { get; set; }
        [Display(Name = "Saving Name")]
        public string SavingName { get; set; }

        [Display(Name = "Target Amount")]
        public decimal TargetAmount { get; set; }

        [Display(Name = "Interest Rate")]
        [Range(minimum: 0, maximum: 100)]
        public int InterestRate { get; set; }

        [Display(Name = "Years")]
        [Range(minimum: 0, maximum: 100)]
        public int Period { get; set; }

        [Display(Name = "Monthly Saving")]
        public decimal MonthlySaving { get; set; }

        public void CalculateMonthlySaving()
        {
            decimal net = TargetAmount / (1 + (InterestRate / 100) * (Period));

            MonthlySaving = net / (Period * 12);
        }
    }
}