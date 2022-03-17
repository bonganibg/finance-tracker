using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTrackerLibrary
{
    public abstract class Loan
    {
        public decimal PurchasePrice { get; set; } // Full prioce of the product
        public decimal TotalDeposit { get; set; } // the amount the user has already paid
        public decimal InterestRate { get; set; } // the interest added onto the item
        public int Period { get; set; } // the amount of time (in months) that the user will repay the loan


        /// <summary>
        /// calculates the amount of money that the user will have to pay every month to repay their loan
        /// </summary>
        /// <returns> the monthly repayment for the loan </returns>
        public virtual decimal CalculateMonthlyRepayment()
        {
            decimal total;

            decimal amount = (PurchasePrice - TotalDeposit) * (1 + (InterestRate / 100) * (Period / 12));
            total = amount / Period;

            return total;
        }
    }
}
