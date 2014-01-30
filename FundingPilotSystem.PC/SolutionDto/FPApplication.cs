using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain.SolutionDto
{

    public static class CurrentFPApplicationContext
    {
        static CurrentFPApplicationContext()
        {

        }

        public static FPApplication GetFPApplication()
        {
            return new FPApplication()
            {
                LoggedInUser = CurrentFPApplicationContext.LoggedInUser ?? new LoggedInUser(),
                

            };
        }
        public static LoggedInUser LoggedInUser
        {
            get
            {
                if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null || System.Web.HttpContext.Current.Session["LoggedInUser"] == null)
                    return null;

                return System.Web.HttpContext.Current.Session["LoggedInUser"] as LoggedInUser;

            }
            set
            {
                System.Web.HttpContext.Current.Session["LoggedInUser"] = value;

            }
        }

        public static string WebUrlPrefix
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["WebUrlPrefix"]);
            }
        }
        public static int CurrentContextUserId
        {
            get
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.UserId;
                }
                return 0;
            }
        }
        public static LoggedInUser CurrentContextUser
        {
            get
            {
                if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Session == null || System.Web.HttpContext.Current.Session["CurrentContextUser"] == null)
                    return null;

                return System.Web.HttpContext.Current.Session["CurrentContextUser"] as LoggedInUser;

            }
            set
            {
                System.Web.HttpContext.Current.Session["CurrentContextUser"] = value;
               
            }
        }


    }

    public class FPApplication
    {
        public string CurrentContextUserName
        {
            get
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.Username ?? string.Empty;
                }
                return "CurrentContextUser == null";
            }
        }

        public int CurrentContextUserId
        {
            get
            {
                if (LoggedInUser != null)
                {
                    return LoggedInUser.UserId;
                }
                return 0;
            }
        }
        public LoggedInUser LoggedInUser { get; set; }

    }
}




