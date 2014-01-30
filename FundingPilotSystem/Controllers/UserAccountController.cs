using FundingPilotSystem.Domain.SolutionDto;
using FundingPilotSystem.VM.UserAccountManagement;
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
            if (loginModel.Username == "rk@yasofttech.com" && loginModel.Password == "admin")
            {
                loginModel.Username = "rk@yasofttech.com";

                CurrentFPApplicationContext.LoggedInUser = new LoggedInUser()
                 {
                     UserId = loginModel.UserId,
                     Password = loginModel.Password,
                     Username = loginModel.Username

                 };

                return RedirectToAction("Index", "Home");
            }
            return View(loginModel);
        }

    }
}
