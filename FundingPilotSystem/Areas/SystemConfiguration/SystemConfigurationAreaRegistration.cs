using System.Web.Mvc;

namespace FundingPilotSystem.Areas.SystemConfiguration
{
    public class SystemConfigurationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SystemConfiguration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SystemConfiguration_default",
                "SystemConfiguration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
