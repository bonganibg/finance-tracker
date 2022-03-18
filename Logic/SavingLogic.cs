using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using FinanceTrackerWebApp.Models;

namespace FinanceTrackerWebApp.Logic
{
    public class SavingLogic
    {
        
         private SqlConnection conn;

         private void Connection()
         {
             string constr = ConfigurationManager.ConnectionStrings["DoDB"].ToString();
             conn = new SqlConnection(constr);
         }

         /// <summary>
         /// Get all of the things the user wants to save for
         /// </summary>
         /// <param name="UserID"> the user whose information is being searched </param>
         /// <returns> a SavingModel list of all of things the user wants to save for </returns>
         public List<SavingModel> GetAllSavings(int UserID)
         {
             Connection();

             SqlCommand GetCommand = new SqlCommand("GetAllSavings", conn);
             GetCommand.CommandType = CommandType.StoredProcedure;
             GetCommand.Parameters.AddWithValue("@UserID", UserID);

             SqlDataAdapter da = new SqlDataAdapter(GetCommand);
             DataTable dt = new DataTable();

             conn.Open();
             da.Fill(dt);
             conn.Close();

             List<SavingModel> savings = new List<SavingModel>();

             foreach(DataRow dr in dt.Rows)
             {
                 savings.Add(new SavingModel { 
                     SavingName = Convert.ToString(dr["Name"]),
                     TargetAmount = Convert.ToDecimal(dr["TargetAmount"]),
                     InterestRate = Convert.ToInt32(dr["InterestRate"]),
                     Period = Convert.ToInt32(dr["Period"]),
                     MonthlySaving = Convert.ToDecimal(dr["MonthlySaving"])
                 });
             }

             return savings;
         }

         /// <summary>
         /// Write the saving information to the database
         /// </summary>
         /// <param name="saving"> the saving information entered </param>
         /// <param name="UserID"> the id for the user</param>
         /// <returns> true or false depending on whether the information was saved </returns>
         public bool CreateNewSaving(SavingModel saving,int UserID)
         {
             Connection();

             SqlCommand WriteCommand = new SqlCommand("WriteSavings", conn);
             WriteCommand.CommandType = CommandType.StoredProcedure;
             WriteCommand.Parameters.AddWithValue("@UserID",UserID);
             WriteCommand.Parameters.AddWithValue("@Name", saving.SavingName);
             WriteCommand.Parameters.AddWithValue("@TargetAmount", saving.TargetAmount);
             WriteCommand.Parameters.AddWithValue("@InterestRate", saving.InterestRate);
             WriteCommand.Parameters.AddWithValue("@Period", saving.Period);
             WriteCommand.Parameters.AddWithValue("@MonthlySaving", saving.MonthlySaving);

             conn.Open();
             int i = WriteCommand.ExecuteNonQuery();
             conn.Close();

             if (i > 0)
                 return true;
             else
                 return false;           

         }


         /// <summary>
         /// Remove the Saving from the list
         /// </summary>
         /// <param name="SavingID"> the id for the saving being removed</param>
         /// <param name="UserID">the id for the user who is removing the saving</param>
         /// <returns></returns>
         public bool DeleteSaving(int SavingID, int UserID)
         {
             Connection();

             SqlCommand DeleteCommand = new SqlCommand("DeleteSaving", conn);
             DeleteCommand.CommandType = CommandType.StoredProcedure;
             DeleteCommand.Parameters.AddWithValue("@UserID",UserID);
             DeleteCommand.Parameters.AddWithValue("@SavingID",SavingID);

             conn.Open();
             int i = DeleteCommand.ExecuteNonQuery();
             conn.Close();

             if (i > 0)
                 return true;
             else
                 return false;
         }
    }
}