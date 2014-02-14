using FundingPilotSystem.Common;
using FundingPilotSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LoggingFramework;
using System.Threading;

namespace FundingPilotSystem.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session["CurrentCulture"] == null)
            {
                session["CurrentCulture"] = Thread.CurrentThread.CurrentCulture.Name;
            }
            ActionDescriptor actionDescriptor = filterContext.ActionDescriptor;
            string currentController = actionDescriptor.ControllerDescriptor.ControllerName ?? string.Empty;
            string currentAction = actionDescriptor.ActionName ?? string.Empty;
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();

            /* Send to Login page if session is null (not logged in) */
            if (!isAjaxRequest
                    && string.Compare(currentAction, "Login", StringComparison.CurrentCultureIgnoreCase) != 0
                    && string.Compare(currentAction, "Register", StringComparison.CurrentCultureIgnoreCase) != 0
                    && string.Compare(currentAction, "GenerateResourceJson", StringComparison.CurrentCultureIgnoreCase) != 0
                )
            {

                if (CurrentFPApplicationContext.LoggedInUser == null && (!session.IsNewSession) || (session.IsNewSession))
                {
                    session.RemoveAll();
                    session.Clear();
                    session.Abandon();

                    //send them off to the login page.
                    // area must be empty to redirect login page.
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                               {
                                                                                   {"action", "Login"},
                                                                                   {"controller", "UserAccount"},
                                                                                   {"area",""},
                                                                                   {"returnUrl",filterContext.HttpContext.Request.RawUrl}
                                                                               });
                }
            }
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// This action will be called after action executed
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string messsage = GetLoggingMessage(filterContext);
            Log4NetLogger.Info(messsage);

            base.OnActionExecuted(filterContext);
        }

        private string GetLoggingMessage(ActionExecutedContext filterContext)
        {
            System.Web.Mvc.ActionDescriptor actionDescriptor = filterContext.ActionDescriptor;
            string currentController = actionDescriptor.ControllerDescriptor.ControllerName ?? string.Empty;
            string currentAction = actionDescriptor.ActionName ?? string.Empty;
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();
            string userId = "NotLoggedId";
            string userName = "NotLoggedId";
            if (CurrentFPApplicationContext.LoggedInUser != null)
            {
                userId = CurrentFPApplicationContext.LoggedInUser.UserId.ToString();
                userName = CurrentFPApplicationContext.LoggedInUser.Username;
            }
            var parameters = filterContext.ActionDescriptor.GetParameters();
            StringBuilder parameterDetails = new StringBuilder();
            foreach (var parameter in parameters)
            {
                try
                {
                    var parameterValue = filterContext.Controller.ValueProvider.GetValue(parameter.ParameterName);
                    if (parameterValue != null)
                    {
                        parameterDetails.AppendFormat("{0} = {1} & ", parameter.ParameterName, System.Text.RegularExpressions.Regex.Replace((parameterValue.AttemptedValue ?? string.Empty).Trim(), @"\s+", " "));
                    }
                }
                catch
                {
                }
            }

            StringBuilder message = new StringBuilder();
            message.AppendFormat("{0};{1};{2};{3};{4};{5};{6};{7};", currentController, currentAction, parameterDetails.ToString().Trim(new char[] { '&' }).Trim(), isAjaxRequest, filterContext.HttpContext.Request.UserHostAddress, filterContext.HttpContext.Timestamp, userId, userName);
            return message.ToString();
        }


        /// <summary>
        /// This method will log all exceptions at UI level
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            string controllerName = filterContext.RouteData.GetRequiredString("controller");
            string actionName = filterContext.RouteData.GetRequiredString("action");
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            string messsage = GetLoggingMessage(filterContext);
            Log4NetLogger.Error(messsage);


            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }

        private string GetLoggingMessage(ExceptionContext filterContext)
        {
            string currentController = filterContext.RouteData.GetRequiredString("controller");
            string currentAction = filterContext.RouteData.GetRequiredString("action");
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();
            string userId = "NotLoggedId";
            string userName = "NotLoggedId";
            if (CurrentFPApplicationContext.LoggedInUser != null)
            {
                userId = CurrentFPApplicationContext.LoggedInUser.UserId.ToString();
                userName = CurrentFPApplicationContext.LoggedInUser.Username;
            }

            StringBuilder message = new StringBuilder();
            message.AppendFormat("{0};{1};{2};{3};{4};{5};{6};{7};", currentController, currentAction, filterContext.Exception, isAjaxRequest, filterContext.HttpContext.Request.UserHostAddress, filterContext.HttpContext.Timestamp, userId, userName);
            return message.ToString();
        }

        /// <summary>
        /// The below method will generate jave script file with json object same as resource file
        /// Object Name will be ICLComResource
        /// </summary>
        /// <returns></returns>
        public JavaScriptResult GenerateResourceJson(string pageName)
        {
            return JSResourceManager.GetResourceScript(pageName);
        }
    }
}
