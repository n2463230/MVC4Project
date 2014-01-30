using System.Web.Mvc;

namespace FundingPilotSystem.Areas.Registration
{
    public class RegistrationProcessAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "RegistrationProcess";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Registration_default",
                "RegistrationProcess/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
