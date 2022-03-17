using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerLibrary
{
    public class HomeLoan : Loan
    {
        public bool LoanApproval; // indicates whether the user monthly repayment for their loan will be more than 1 third of their income

        /// <summary>
        /// Overrides the monthly repayment calculation and determines if the users income will be enough to get loan approval
        /// </summary>
        /// <returns> the monthly repayment </returns>
        public override decimal CalculateMonthlyRepayment()
        {
            decimal amount = base.CalculateMonthlyRepayment();

            if (amount > (FinanceTracker.GrossMonthlyIncome / 3))
                LoanApproval = false;
            else
                LoanApproval = true;

            return amount;
        }
    }
}
