using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceTrackerWebApp.Logic;
using FinanceTrackerWebApp.Models;
using FinanceTrackerLibrary;

namespace FinanceTrackerWebApp.Controllers
{
    public class FinanceController : Controller
    {
        public static bool bBuyHouse, bVehicle;

        // GET: Finance
        public ActionResult ViewFinances()
        {
            FinanceTrackerLogic ftl = new FinanceTrackerLogic();
            ModelState.Clear();
            return View(ftl.GetFinanceDetails(HomeController.user.UserID));
        }

        /// <summary>
        /// enter the income and the tax deduction
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterIncomeInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterIncomeInfo(FinanceModel finance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FinanceTrackerLogic ftl = new FinanceTrackerLogic();
                    ftl.WriteIncomeDetails(finance,HomeController.user.UserID);

                    return RedirectToAction("EnterExpenses");
                   
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// Enter the basic expenses
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterExpenses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterExpenses(FinanceModel finance)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    bBuyHouse = finance.BuyHouse;
                    bVehicle = finance.BuyVehicle;

                    FinanceTrackerLogic ftl = new FinanceTrackerLogic();

                    ftl.WriteExpenses(finance,HomeController.user.UserID);

                    if (bBuyHouse)
                        return RedirectToAction("EnterHomeLoan");
                    else
                        return RedirectToAction("RentHouse"); 
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// enter the monthly rent paid
        /// </summary>
        /// <returns></returns>
        public ActionResult RentHouse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RentHouse(FinanceModel finance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FinanceTrackerLogic ftl = new FinanceTrackerLogic();
                    ftl.AddHome(finance.House, HomeController.user.UserID);

                    if (bVehicle)
                        return RedirectToAction("EnterVehicleLoan"); 
                    else
                            return RedirectToAction("ViewFinances");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Home Loan information 
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterHomeLoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterHomeLoan(LoanModel home)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    home.WriteToHome();
                    LoanLogic loan = new LoanLogic();
                    loan.EnterHomeLoanInfo(home.GetHomeLoan(),HomeController.user.UserID);

                    if (bVehicle)
                        return RedirectToAction("EnterVehicleLoan");
                    else
                          return RedirectToAction("ViewFinances");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Vehicle loan information 
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterVehicleLoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnterVehicleLoan(LoanModel vehicle)
        {
            try
            {
                vehicle.WriteToVehicle();
                LoanLogic loan = new LoanLogic();

                if (loan.WriteVehicleLoanInfo(vehicle.GetVehicleLoan(), HomeController.user.UserID))
                    return RedirectToAction("ViewFinances");
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }

    }
}