using FundingPilotSystem.Areas.UserManagement.Models;
using FundingPilotSystem.Domain.SolutionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FundingPilotSystem.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            ActionDescriptor actionDescriptor = filterContext.ActionDescriptor;
            string currentController = actionDescriptor.ControllerDescriptor.ControllerName ?? string.Empty;
            string currentAction = actionDescriptor.ActionName ?? string.Empty;
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();

            /* Send to Login page if session is null (not logged in) */
            if (!isAjaxRequest && string.Compare(currentAction, "Login", StringComparison.CurrentCultureIgnoreCase) != 0)
            {

                if (CurrentFPApplicationContext.LoggedInUser == null && (!session.IsNewSession) || (session.IsNewSession))
                {
                    session.RemoveAll();
                    session.Clear();
                    session.Abandon();

                    //send them off to the login page
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                                                               {
                                                                                   {"action", "Login"},
                                                                                   {"controller", "UserAccount"},
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
            System.Web.Mvc.ActionDescriptor actionDescriptor = filterContext.ActionDescriptor;
            string currentController = actionDescriptor.ControllerDescriptor.ControllerName ?? string.Empty;
            string currentAction = actionDescriptor.ActionName ?? string.Empty;
            bool isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();

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

            WebAccessLogModel webAccessLogModel = new WebAccessLogModel
            {
                Controller = currentController,
                Action = currentAction,
                Parameters = parameterDetails.ToString().Trim(new char[] { '&' }).Trim(),
                IsAjaxRequest = isAjaxRequest,
                IP = filterContext.HttpContext.Request.UserHostAddress,
                DateTime = filterContext.HttpContext.Timestamp,
                UserId = CurrentFPApplicationContext.LoggedInUser.UserId,
                UserName = CurrentFPApplicationContext.LoggedInUser.Username,
            };

            AccessLog.WriteWebAccessLog(webAccessLogModel);

            base.OnActionExecuted(filterContext);
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

            //BLL.LogGenerator.Info(string.Format("ControllerName: {0}", controllerName));
            //BLL.LogGenerator.Info(string.Format("ActionName: {0}", actionName));
            //BLL.LogGenerator.Error("OnException: ", filterContext.Exception);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}
