using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSSReport.App_Start;
using TSSReport.Models;
using TSSReport.Repository;

namespace TSSReport.Controllers
{
    [ErrorFilterAttribute]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = LoginRepository.ValidateUserLogin(loginModel);
                Session["UserDetails"] = result;

                return RedirectToAction("Index", "Report");

            }
            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Login");

        }
    }
}