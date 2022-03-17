using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FinanceTrackerWebApp.Models;
using FinanceTrackerLibrary;

namespace FinanceTrackerWebApp.Logic
{
    public class FinanceTrackerLogic
    {
        
        private SqlConnection conn;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DoDB"].ToString();
            conn = new SqlConnection(constr);
        }

        /// <summary>
        /// Get the monthly income detais for the user
        /// </summary>
        /// <param name="UserID"> the ID for the user whose information is being retrieved </param>
        /// <returns> the financial information for a user </returns>
        public FinanceModel GetFinanceDetails(int UserID)
        {
            Connection();

            FinanceModel finance = new FinanceModel();

            SqlCommand GetCommand = new SqlCommand("GetFinanceDetails", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            GetCommand.Parameters.AddWithValue("@UserID", UserID);

            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                finance.Income = Convert.ToDecimal(dr["Income"]);
                finance.TaxDeduction = Convert.ToDecimal(dr["Tax"]);
                finance.Groceries = Convert.ToDecimal(dr["Groceries"]);
                finance.Utilities = Convert.ToDecimal(dr["Utilities"]);
                finance.Travel = Convert.ToDecimal(dr["Travel"]);
                finance.Phone = Convert.ToDecimal(dr["Phone"]);
                finance.Other = Convert.ToDecimal(dr["Other"]);
                finance.House = Convert.ToDecimal(dr["Home"]);
                finance.Vehicle = Convert.ToDecimal(dr["Vehicle"]);
                finance.AvailableMoney = Convert.ToDecimal(dr["AvailableMoney"]);
            }

            FinanceTracker ft = new FinanceTracker();
            FinanceTracker.GrossMonthlyIncome = finance.Income;
            ft.TaxDeduction = finance.TaxDeduction;
            ft.AddExpense("Groceries", finance.Groceries);
            ft.AddExpense("Utilities", finance.Utilities);
            ft.AddExpense("Travel", finance.Travel);
            ft.AddExpense("Phone", finance.Phone);
            ft.AddExpense("Other", finance.Other);
            ft.AddExpense("House", finance.House);
            ft.AddExpense("Vehicle", finance.Vehicle);

            finance.AvailableMoney = ft.AvailableMoney();

            return finance;
        }


        /// <summary>
        /// /Write the income details to the database
        /// </summary>
        /// <param name="finance"> income infomation</param>
        /// <param name="UserID"> the user whose information is being added</param>
        /// <returns></returns>
        public bool WriteIncomeDetails(FinanceModel finance, int UserID)
        {
            Connection();

            SqlCommand WriteCommand = new SqlCommand("WriteIncome",conn);
            WriteCommand.CommandType = CommandType.StoredProcedure;
            WriteCommand.Parameters.AddWithValue("@UserID", UserID);
            WriteCommand.Parameters.AddWithValue("@Income", finance.Income);
            WriteCommand.Parameters.AddWithValue("@Tax", finance.TaxDeduction);

            conn.Open();
            int i = WriteCommand.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Write the expenses to the database
        /// </summary>
        /// <param name="finance"> the expense information </param>
        /// <param name="UserID"> the user whose information is being changed</param>
        /// <returns></returns>
        public bool WriteExpenses(FinanceModel finance, int UserID)
        {
            Connection();

            SqlCommand WriteCommand = new SqlCommand("WriteExpenses",conn);
            WriteCommand.CommandType = CommandType.StoredProcedure;
            WriteCommand.Parameters.AddWithValue("@UserID", UserID);
            WriteCommand.Parameters.AddWithValue("@Income",finance.Income);
            WriteCommand.Parameters.AddWithValue("@Tax",finance.TaxDeduction);
            WriteCommand.Parameters.AddWithValue("@Groceries", finance.Groceries);
            WriteCommand.Parameters.AddWithValue("@Utilities", finance.Utilities);
            WriteCommand.Parameters.AddWithValue("@Travel", finance.Travel  );
            WriteCommand.Parameters.AddWithValue("@Phone", finance.Phone);
            WriteCommand.Parameters.AddWithValue("@Other", finance.Other);

            conn.Open();
            int i = WriteCommand.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Write the rental amount to the database
        /// </summary>
        /// <param name="Amount"> the rent amount</param>
        /// <param name="UserID"> the user whose informmation is being adds ID</param>
        /// <returns></returns>
        public bool AddHome(decimal Amount, int UserID)
        {
            Connection();

            SqlCommand WriteCommand = new SqlCommand("WriteRent", conn);
            WriteCommand.CommandType = CommandType.StoredProcedure;
            WriteCommand.Parameters.AddWithValue("@UserID",UserID);
            WriteCommand.Parameters.AddWithValue("@Amount",Amount);

            conn.Open();
            int i = WriteCommand.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
                return true;
            else
                return false;

        }
        
         
         



    }
}