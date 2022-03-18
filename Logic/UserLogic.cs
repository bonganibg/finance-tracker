using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinanceTrackerWebApp.Models;
using FinanceTrackerWebApp.Controllers;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FinanceTrackerWebApp.Logic
{
    public class UserLogic
    {
        
        private SqlConnection conn;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DoDB"].ToString();
            conn = new SqlConnection(constr);
        }

        private int CheckIfUserExists(UserModel user)
        {
            Connection();

            SqlCommand GetCommand = new SqlCommand("CheckIfUserExists", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            GetCommand.Parameters.AddWithValue("@Username", user.Username);
            GetCommand.Parameters.AddWithValue("@Password", user.Password.GetHashCode());

            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();

            int UserID = -100;

            foreach (DataRow dr in dt.Rows)
            {
                UserID = Convert.ToInt32(dr["UserID"]);
            }

            return UserID;
        }

        /// <summary>
        /// Log the user in
        /// </summary>
        /// <param name="user"> the username and password entered </param>
        /// <returns> true or false depending on whether the users details were correct </returns>
        public bool Login(UserModel user)
        {
            int UserID = CheckIfUserExists(user);

            if (UserID == -100)
                return false;
            else
            {
                HomeController.user.Username = user.Username;
                HomeController.user.Password = user.Password;
                HomeController.user.UserID = UserID;
                return true;
            }
        }


        /// <summary>
        /// Create a new account for a user
        /// </summary>
        /// <param name="user">  the user name and password entered </param>
        /// <returns>true or false if the users information is correct </returns>
        public bool CreateNewUser(UserModel user)
        {
            int UserID = CheckIfUserExists(user);

            if (UserID == -100)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    Connection();

                    SqlCommand CreateCommand = new SqlCommand("CreateNewUser", conn);
                    CreateCommand.CommandType = CommandType.StoredProcedure;
                    CreateCommand.Parameters.AddWithValue("@Username", user.Username);
                    CreateCommand.Parameters.AddWithValue("@Password", user.Password.GetHashCode());

                    conn.Open();
                    int i = CreateCommand.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}