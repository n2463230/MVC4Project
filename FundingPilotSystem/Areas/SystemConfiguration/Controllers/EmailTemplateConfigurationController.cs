using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundingPilotSystem.Common;
using FundingPilotSystem.Utilities;
using FundingPilotSystem.VM;
using Telerik.Web.Mvc;

namespace FundingPilotSystem.Areas.SystemConfiguration.Controllers
{
    public class EmailTemplateConfigurationController : Controller
    {
        #region [Declaration]

        private FundingPilotSystem.Services.FPConfigurationService.IFPConfigurationService FPConfigurationService { get; set; }
        private FundingPilotSystem.Services.MasterDataProviderService.IMasterDataProviderService MasterConfigurationService { get; set; }
        private ProcessEmailTemplateVM CurrentProcessEmailTemplateVM { get; set; }

        #endregion

        #region [Constructor]

        public EmailTemplateConfigurationController()
        {
            this.FPConfigurationService = ServiceReferences.GetFPConfigurationServiceClient();
            this.MasterConfigurationService = ServiceReferences.GetMasterProviderServiceClient();
        }

        #endregion

        #region [Controller Actions]

        /// <summary>
        /// List All Email Configurations
        /// </summary>
        /// <returns></returns>
        public ActionResult ListAll()
        {
            CacheManager.ProcessEmailTemplateVMList = FPConfigurationService.GetAllProcessEmailTemplate();
            return View("ListAll");
        }

        /// <summary>
        /// Load the attachments of the selected inspection in the history window
        /// </summary>
        /// <param name="inspectionActivityId"></param>
        /// <returns></returns>
        [GridAction]
        public ActionResult ListAllAjax()
        {
            if (CacheManager.ProcessEmailTemplateVMList == null)
            {
                CacheManager.ProcessEmailTemplateVMList = FPConfigurationService.GetAllProcessEmailTemplate();
            }

            return View(new GridModel { Data = CacheManager.ProcessEmailTemplateVMList });
        }

        /// <summary>
        /// Update Email Configuration
        /// </summary>
        /// <returns></returns>       
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Save(int? id)
        {
            ActivateForm(id ?? 0);
            return View("Save", CurrentProcessEmailTemplateVM);
        }

        /// <summary>
        /// Update Email Configuration
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        /// [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(ProcessEmailTemplateVM viewModel)
        {
            CurrentProcessEmailTemplateVM = viewModel;
            CheckFormValidation();

            if (!ModelState.IsValid)
            {
                FillCombo();
                return View("Save", CurrentProcessEmailTemplateVM);
            }
            else
            {
                if (CurrentProcessEmailTemplateVM.Id == 0)
                {
                    CurrentProcessEmailTemplateVM.CreatedOn = DateTime.Now;
                    CurrentProcessEmailTemplateVM.CreatedBy = CurrentFPApplicationContext.LoggedInUser.Username;
                }
                else
                {
                    CurrentProcessEmailTemplateVM.ModifiedOn = DateTime.Now;
                    CurrentProcessEmailTemplateVM.ModifiedBy = CurrentFPApplicationContext.LoggedInUser.Username;
                }

                CurrentProcessEmailTemplateVM.IPAddressOfLastAction = CurrentFPApplicationContext.LoggedInUser.IPAddress;
                FPConfigurationService.SaveProcessEmailTemplate(CurrentProcessEmailTemplateVM);
            }

            return RedirectToAction("ListAll");
        }

        /// <summary>
        /// Delete Email Template Configuration
        /// </summary>
        /// <param name="emailTemplateConfigurationId"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Delete(int emailTemplateConfigurationId)
        {
            var deleteResult = FPConfigurationService.DeleteProcessEmailTemplate(emailTemplateConfigurationId);
            CacheManager.ProcessEmailTemplateVMList = FPConfigurationService.GetAllProcessEmailTemplate();
            return deleteResult;
        }

        #endregion

        #region [Methods]

        private void ActivateForm(int id)
        {
            if (id > 0)
            {
                CurrentProcessEmailTemplateVM = FPConfigurationService.GetProcessEmailTemplate(id);
            }
            else
            {
                CurrentProcessEmailTemplateVM = new ProcessEmailTemplateVM();                
            }
            FillCombo();
        }

        private void FillCombo()
        {
            //Process Combo
            if (CacheManager.ProcessEmailTemplateVMList == null)
            {
                CacheManager.ProcessEmailTemplateVMList = FPConfigurationService.GetAllProcessEmailTemplate();
            }

            var processDdl = FPConfigurationService.GetAllProcess();

            CurrentProcessEmailTemplateVM.ProcessDdl = (from p in processDdl
                                                        where (CurrentProcessEmailTemplateVM.ProcessId > 0 
                                                                    || CacheManager.ProcessEmailTemplateVMList.Where(l => l.ProcessId == p.Id).Count() == 0)
                                                        select p).ToList();

            CurrentProcessEmailTemplateVM.ProcessDdl.Insert(0, new ProcessVM() { Id = 0, ProcessName = CustomLocalizationUtility.GetKeyValue("CommonResource", "Select") });

        }

        private void CheckFormValidation()
        {
            if (CurrentProcessEmailTemplateVM.ProcessId == 0)
            {
                ModelState.AddModelError("ProcessId", @CustomLocalizationUtility.GetKeyValue("SystemConfigurationResources", "ValidationRequiredProcess"));
            }

            if (string.IsNullOrWhiteSpace(CurrentProcessEmailTemplateVM.EmailContent))
            {
                ModelState.AddModelError("EmailContent", @CustomLocalizationUtility.GetKeyValue("SystemConfigurationResources", "ValidationRequiredEmailContents"));
            }
            else
            {
                CurrentProcessEmailTemplateVM.EmailContent = CurrentProcessEmailTemplateVM.EmailContent.Trim();
                CurrentProcessEmailTemplateVM.EmailContent = CurrentProcessEmailTemplateVM.EmailContent.Replace("&nbsp;", "");
            }
        }

        #endregion
    }

}
