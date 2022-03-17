using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTrackerLibrary
{
    public class FinanceTracker
    {
        public static decimal GrossMonthlyIncome { get; set; } // store the users income
        private Dictionary<string, decimal> Expense = new Dictionary<string, decimal>(); // store all of the users expenses
        public decimal TaxDeduction { get; set; } // storet the tax deductions

        /// <summary>
        /// creates the elements for the dict that will hold all of the users expenses
        /// </summary>
        public FinanceTracker()
        {
            Expense.Add("Groceries", 0);
            Expense.Add("Utilities", 0);
            Expense.Add("Travel", 0);
            Expense.Add("Phone", 0);
            Expense.Add("Other", 0);
            Expense.Add("House", 0);
            Expense.Add("Vehicle", 0);
        }

        /// <summary>
        /// Adds the amount of money the user will spend on an expense to the dictionary
        /// </summary>
        /// <param name="expenseName"> The name of the expense that needs to have a value added </param>
        /// <param name="amount"> The amount of money that will be used for the expense </param>
        public void AddExpense(string expenseName, decimal amount)
        {
            Expense[expenseName] = amount;
        }

        /// <summary>
        /// finds the value of a certian expense that the user is looking for
        /// </summary>
        /// <param name="expenseName"> the expense that the user wants to find </param>
        /// <returns> the value of the expense </returns>
        public decimal GetExpense(string expenseName)
        {
            return Expense[expenseName];
        }

        public Dictionary<string,decimal> GetAllExpenses()
        {
            return Expense;
        }

        /// <summary>
        /// calculates the values that the user has provided and subtracts the expenses from the users income
        /// </summary>
        /// <returns> the amount of money that the user will have at the end of the month </returns>
        public decimal AvailableMoney()
        {
            decimal difference = GrossMonthlyIncome - (Expense.Values.Sum() + TaxDeduction);
            return difference;
        }
    }
}
