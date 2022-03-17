using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanceTrackerWebApp.Models;
using FinanceTrackerWebApp.Logic;

namespace FinanceTrackerWebApp.Controllers
{
    public class HomeController : Controller
    {
        public static UserModel user = new UserModel();

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserLogic userLogic = new UserLogic();

                if (userLogic.CreateNewUser(user))
                {
                    if (userLogic.Login(user))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserLogic userLogic = new UserLogic();

                if(userLogic.Login(user))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult Index()
        {
            if (!String.IsNullOrEmpty(user.UserID.ToString()))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}