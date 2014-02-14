using FundingPilotSystem.Common;
using FundingPilotSystem.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FundingPilotSystem.Controllers
{
    public class UserAccountController : Controller
    {
        #region Declarations

        public LoginViewModel loginModel { get; set; }

        #endregion
        public ActionResult Login()
        {
            loginModel = new LoginViewModel();
            return View(loginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (loginModel.Username == "ad@itmcsoft.com" && loginModel.Password == "admin")
            {
                loginModel.Username = "ad@itmcsoft.com";

                CurrentFPApplicationContext.LoggedInUser = new LoggedInUser()
                 {
                     UserId = loginModel.UserId,
                     Password = loginModel.Password,
                     Username = loginModel.Username,
                     IPAddress = System.Web.HttpContext.Current.Request.UserHostAddress,
                 };

                if (HttpContext.Request.QueryString["returnUrl"] != null)
                {
                    string returnUrl = HttpContext.Request.QueryString["returnUrl"].ToString();
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            return View(loginModel);
        }

    }
}
