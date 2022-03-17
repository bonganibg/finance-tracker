using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceTrackerWebApp.Models;
using FinanceTrackerWebApp.Logic;
using FinanceTrackerWebApp.Controllers;

namespace FinanceTrackerWebApp.Controllers
{
    public class SavingController : Controller
    {
        // GET: Saving
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// create a new thing to save for 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateSaving()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSaving(SavingModel saving)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    saving.CalculateMonthlySaving();

                    SavingLogic savingLogic = new SavingLogic();

                    if (savingLogic.CreateNewSaving(saving, HomeController.user.UserID))
                    {
                        ViewBag.AlertMsg = "Information saved";
                    }
                    return RedirectToAction("GetAllSavings");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// shows all of the savings that the user wants to do
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllSavings()
        {
            SavingLogic saving = new SavingLogic();
            ModelState.Clear();
            return View(saving.GetAllSavings(HomeController.user.UserID));
        }


        public ActionResult DeleteSaving(int id)
        {
            try
            {
                SavingLogic saving = new SavingLogic();
                if (saving.DeleteSaving(id, HomeController.user.UserID))
                {
                    ViewBag.AlertMsg = "Saving deleted successfully";
                }
                return RedirectToAction("GetAllSavings");
            }
            catch
            {

                return View();
            }
        }




    }
}