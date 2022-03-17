using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FinanceTrackerWebApp.Models;
using FinanceTrackerLibrary;
using FinanceTrackerWebApp.Logic;
using FinanceTrackerWebApp.Controllers;

namespace FinanceTrackerWebApp.Logic
{
    public class DataLogic
    {
        private static int UserID = HomeController.user.UserID;
        public static FinanceTracker ft = new FinanceTracker();
        public static HomeLoan home = new HomeLoan();
        public static VehicleLoan vehicle = new VehicleLoan();
        public static bool bVehicle;
        public static bool bBuyHouse;

        //public static void LoadUserData()
        //{
        //    LoanLogic loan = new LoanLogic();
        //    home = loan.GetHomeLoanInfo(UserID);
        //    vehicle = loan.GetVehicleLoanInfo(UserID);

        //    FinanceTrackerLogic financeLogic = new FinanceTrackerLogic();

        //    FinanceModel finance = financeLogic.GetFinanceDetails(UserID);

        //    if (finance != null)
        //    {
        //        FinanceTracker.GrossMonthlyIncome = finance.Income;
        //        ft.TaxDeduction = finance.TaxDeduction;

        //        ft.AddExpense("Groceries", finance.Groceries);
        //        ft.AddExpense("Utilities", finance.Utilities);
        //        ft.AddExpense("Travel", finance.Travel);
        //        ft.AddExpense("Phone", finance.Phone);
        //        ft.AddExpense("Other", finance.Other);
        //        ft.AddExpense("House", finance.House);
        //        ft.AddExpense("Vehicle", finance.Vehicle);

        //    }
        //}

        //public static FinanceModel ViewFinances()
        //{
        //    FinanceTrackerLogic financeLogic = new FinanceTrackerLogic();

        //    FinanceModel finance = new FinanceModel();

        //    finance.Income = FinanceTracker.GrossMonthlyIncome;
        //    finance.TaxDeduction = ft.TaxDeduction;

        //    finance.Groceries = ft.GetExpense("Groceries");
        //    finance.Utilities = ft.GetExpense("Utilities");
        //    finance.Travel = ft.GetExpense("Travel");
        //    finance.Phone = ft.GetExpense("Phone");
        //    finance.Other = ft.GetExpense("Other");
        //    finance.House = ft.GetExpense("House");
        //    finance.Vehicle = ft.GetExpense("Vehicle");

        //    return finance;
        //}

        //public static void WriteIncomeDetails(FinanceModel finance)
        //{
        //    FinanceTracker.GrossMonthlyIncome = finance.Income;
        //    ft.TaxDeduction = finance.TaxDeduction;
        //}

        //public static void WriteExpenses(FinanceModel finance)
        //{

        //    ft.AddExpense("Groceries", finance.Groceries);
        //    ft.AddExpense("Utilities", finance.Utilities);
        //    ft.AddExpense("Travel", finance.Travel);
        //    ft.AddExpense("Phone", finance.Phone);
        //    ft.AddExpense("Other", finance.Other);


        //}

        //public static bool SaveInformation()
        //{
        //    LoanLogic loan = new LoanLogic();

        //    if (bVehicle)
        //    {
        //        ft.AddExpense("Vehicle", vehicle.CalculateMonthlyRepayment());
        //        loan.WriteVehicleLoanInfo(vehicle, HomeController.user.UserID);
        //    }
        //    else
        //    {
        //        ft.AddExpense("Vehicle", 0);
        //    }

        //    if (bBuyHouse)
        //    {
        //        ft.AddExpense("House", home.CalculateMonthlyRepayment());
        //        loan.EnterHomeLoanInfo(home, HomeController.user.UserID);
        //    }


        //    FinanceTrackerLogic financeLogic = new FinanceTrackerLogic();

        //    FinanceModel finance = new FinanceModel();

        //    finance.Income = FinanceTracker.GrossMonthlyIncome;
        //    finance.TaxDeduction = ft.TaxDeduction;

        //    finance.Groceries = ft.GetExpense("Groceries");
        //    finance.Utilities = ft.GetExpense("Utilities");
        //    finance.Travel = ft.GetExpense("Travel");
        //    finance.Phone = ft.GetExpense("Phone");
        //    finance.Other = ft.GetExpense("Other");
        //    finance.House = ft.GetExpense("House");
        //    finance.Vehicle = ft.GetExpense("Vehicle");

        //    //return financeLogic.WriteFinanceInformation(finance,ft.AvailableMoney(),HomeController.user.UserID);
        //}

    }
}