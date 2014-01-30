using FundingPilotSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using FundingPilotSystem.Domain;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FundingPilotSystem.Services.FPMasterValues.MasterDataProviderService;

namespace FundingPilotSystem
{
    public class HomeController : Controller
    {
        private IMasterDataProviderService _masterProviderService;
        public HomeController()
        {
            this._masterProviderService = ServiceReferences.GetMasterProviderServiceClient();
        }
        public HomeController(IMasterDataProviderService masterProviderService)
        {
            this._masterProviderService = masterProviderService;
        }
        //
        // GET: /Home/
        [HandleError]
        public ActionResult Index()
        {
            LoggingFramework.Log4NetLogger.Info("UI: In Home/Index");
            ViewBag.Countries = CommonUtility.GetCountries(_masterProviderService);
            return View();

        }

    }
}
