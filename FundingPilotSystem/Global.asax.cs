using FundingPilotSystem.Common;
using FundingPilotSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace FundingPilotSystem
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(CustomRequiredAttribute)
                                            , typeof(RequiredAttributeAdapter));

            CommonUtility.SetCurrentCulture(CultureInfo.CurrentCulture.Name);
        }

        protected void Session_Start()
        {
            //Set this to access localization
            var _masterDataProviderService = FundingPilotSystem.Utilities.ServiceReferences.GetMasterProviderServiceClient();
            if (CustomLocalizationUtility.SystemModuleList == null)
            {
                var systemModuleList = _masterDataProviderService.GetSystemModules();
                CustomLocalizationUtility.SystemModuleList = (from module in systemModuleList
                                                              select new FundingPilotSystem.Common.SystemModule
                                                              {
                                                                  Id = module.Id,
                                                                  Module = module.Module,
                                                                  ResourceFileName = module.ResourceFileName,
                                                                  ResourceFolderName = module.ResourceFolderName,
                                                              }).ToList();
            }
        }
    }
}