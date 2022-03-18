using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FinanceTrackerLibrary;
using FinanceTrackerWebApp.Models;
using System.Data;

namespace FinanceTrackerWebApp.Logic
{
    public class LoanLogic
    {       
        private SqlConnection conn;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DoDB"].ToString();
            conn = new SqlConnection(constr);
        }

        /// <summary>
        /// Get home loan information for the user
        /// </summary>
        /// <param name="UserID"> the ID for the user  </param>
        /// <returns> information about the homeloan </returns>
        public HomeLoan GetHomeLoanInfo(int UserID)
        {
            Connection();

            HomeLoan home = new HomeLoan();

            SqlCommand GetCommand = new SqlCommand("GetHomeLoan", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            GetCommand.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach(DataRow dr in dt.Rows)
            {
                home.PurchasePrice = Convert.ToDecimal(dr["PurchasePrice"]);
                home.TotalDeposit = Convert.ToDecimal(dr["TotalDeposit"]);
                home.InterestRate = Convert.ToDecimal(dr["InterestRate"]);
                home.Period = Convert.ToInt32(dr["NumOfMonths"]);
            }

            return home;
        }

        /// <summary>
        /// set the values for the home loan
        /// </summary>
        /// <param name="home"> the information the user has entered </param>
        /// <param name="UserID"> the users ID</param>
        /// <returns>true or false depending on whether the information was added </returns>
        public bool EnterHomeLoanInfo(HomeLoan home, int UserID)
        {
            Connection();

            SqlCommand WriteCommand = new SqlCommand("WriteHomeLoan", conn);
            WriteCommand.CommandType = CommandType.StoredProcedure;
            WriteCommand.Parameters.AddWithValue("@UserID",UserID);
            WriteCommand.Parameters.AddWithValue("@PurchasePrice", home.PurchasePrice);
            WriteCommand.Parameters.AddWithValue("@TotalDeposit", home.TotalDeposit);
            WriteCommand.Parameters.AddWithValue("@InterestRate", home.InterestRate);
            WriteCommand.Parameters.AddWithValue("@NumOfMonths", home.Period);

            conn.Open();
            int i = WriteCommand.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// gets the vehicle loan information from the database
        /// </summary>
        /// <param name="UserID">the user whose infomraiton is being searched</param>
        /// <returns>the vehicle loan information</returns>
        public VehicleLoan GetVehicleLoanInfo(int UserID)
        {
            Connection();

            VehicleLoan vehicle = new VehicleLoan();

            SqlCommand GetCommand = new SqlCommand("GetVehicleLoan", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            GetCommand.Parameters.AddWithValue("@UserID",UserID);
            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                vehicle.Make = Convert.ToString(dr["Make"]);
                vehicle.Model = Convert.ToString(dr["Model"]);
                vehicle.PurchasePrice = Convert.ToDecimal(dr["PurchasePrice"]);
                vehicle.TotalDeposit = Convert.ToDecimal(dr["TotalDeposit"]);
                vehicle.InsurancePremium = Convert.ToDecimal(dr["InsurancePremium"]);
            }

            return vehicle;
        }

        /// <summary>
        /// Write vehicle loan information to the database
        /// </summary>
        /// <param name="vehicle">vehicle information entered by the user</param>
        /// <param name="UserID">the users ID</param>
        /// <returns>true or false depending on whether the information was successfully writtens</returns>
        public bool WriteVehicleLoanInfo(VehicleLoan vehicle, int UserID)
        {
            Connection();
                
            SqlCommand WriteCommand = new SqlCommand("WriteVehicleLoan", conn);
            WriteCommand.CommandType = CommandType.StoredProcedure;
            WriteCommand.Parameters.AddWithValue("@UserID", UserID);
            WriteCommand.Parameters.AddWithValue("@Make", vehicle.Make);
            WriteCommand.Parameters.AddWithValue("@Model", vehicle.Model);
            WriteCommand.Parameters.AddWithValue("@PurchasePrice", vehicle.PurchasePrice);
            WriteCommand.Parameters.AddWithValue("@TotalDeposit", vehicle.TotalDeposit);
            WriteCommand.Parameters.AddWithValue("@InterestRate", vehicle.InterestRate);
            WriteCommand.Parameters.AddWithValue("@Insurance", vehicle.InsurancePremium);

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