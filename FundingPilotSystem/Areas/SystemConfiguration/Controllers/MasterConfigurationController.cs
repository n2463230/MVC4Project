using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundingPilotSystem.Controllers;
using FundingPilotSystem.VM;
using FundingPilotSystem.Services.FPConfigurationService;
using FundingPilotSystem.Utilities;
using FundingPilotSystem.Common;

namespace FundingPilotSystem.Areas.SystemConfiguration.Controllers
{
    public class MasterConfigurationController : BaseController
    {
        #region [Declaration]

        private IFPConfigurationService _fpConfigurationService;

        #endregion

        #region [Constructor]

        public MasterConfigurationController()
        {
            _fpConfigurationService = ServiceReferences.GetFPConfigurationServiceClient();
        }

        #endregion

        #region [Action]

        /// <summary>
        /// Save master configuration
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Save()
        {
            LoggingFramework.Log4NetLogger.Info("UI: In Areas/SystemConfiguration/MasterConfiguration/Save");
            var localizationSettingsVM = _fpConfigurationService.GetMasterConfiguration();
            localizationSettingsVM.EmailAccountUserPassword = Encryption.DecryptToBase64(localizationSettingsVM.EmailAccountUserPassword);
            return View(localizationSettingsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MasterConfigurationViewModel localizationSettingsVM)
        {
            if (ModelState.IsValid)
            {
                LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}", "UI: In Areas/SystemConfiguration/MasterConfiguration/Save", localizationSettingsVM));
                localizationSettingsVM.ModifiedBy = CurrentFPApplicationContext.LoggedInUser.Username;
                localizationSettingsVM.ModifiedOn = System.DateTime.Now;
                localizationSettingsVM.IPAddressOfLastAction = CurrentFPApplicationContext.LoggedInUser.IPAddress;
                localizationSettingsVM.EmailAccountUserPassword = Encryption.EncryptToBase64(localizationSettingsVM.EmailAccountUserPassword.Trim());
                var result = _fpConfigurationService.SaveMasterConfiguration(localizationSettingsVM);
                if (result > 0)
                {
                    localizationSettingsVM.ModelMessage.Add(new Common.ModelMessage { Type = MessageType.Success, Message = CustomLocalizationUtility.GetKeyValue("CommonResource", "MessageSavedSuccess") });
                }
                else
                {
                    localizationSettingsVM.ModelMessage.Add(new Common.ModelMessage { Type = MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("CommonResource", "ErrorPerformingOperation") });
                }
                localizationSettingsVM.EmailAccountUserPassword = Encryption.DecryptToBase64(localizationSettingsVM.EmailAccountUserPassword.Trim());
            }
            return View(localizationSettingsVM);
        }

        #endregion

        #region [Method]

        #endregion
    }
}
