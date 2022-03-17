using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerLibrary
{
    public class VehicleLoan : Loan
    {
        public string Make { get; set; } // the vehicles make
        public string Model { get; set; } // the model of vehicle
        public decimal InsurancePremium { get; set; } // the amount of money the user will spend on insurance per month

        public VehicleLoan()
        {
            Period = 5 * 12; // set the period to 60 months
        }

        /// <summary>
        /// Overrides the monthly repayments calculations and adds the monthly payment for insurance to the monthly total 
        /// </summary>
        /// <returns> The total amount paid for the car every month including insurance </returns>
        public override decimal CalculateMonthlyRepayment()
        {
            decimal carRepayment = base.CalculateMonthlyRepayment();
            return carRepayment + InsurancePremium;
        }
    }
}
