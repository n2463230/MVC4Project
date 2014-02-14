using FundingPilotSystem.Common;
using FundingPilotSystem.Controllers;
using FundingPilotSystem.Services.FPConfigurationService;
using FundingPilotSystem.Services.MasterDataProviderService;
using FundingPilotSystem.Utilities;
using FundingPilotSystem.VM;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.Mvc;

namespace FundingPilotSystem.Areas.SystemConfiguration.Controllers
{
    public class HTMLTemplateManagerController : BaseController
    {
        #region [Declaration]

        private IFPConfigurationService _FPConfigurationService;
        private IMasterDataProviderService _masterDataProviderService;

        #endregion

        #region [Constructor]

        public HTMLTemplateManagerController()
        {
            this._FPConfigurationService = ServiceReferences.GetFPConfigurationServiceClient();
            this._masterDataProviderService = ServiceReferences.GetMasterProviderServiceClient();
        }

        #endregion

        #region [Action Method]

        #region [ManageStaticHTMLPages]

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListAll()
        {
            return View();
        }

        /// <summary>
        /// Returns list of static html page
        /// </summary>
        /// <returns></returns>
        [GridAction]
        public ActionResult ListAllAjax()
        {
            var pageSpecificPlaceholderConfigList = _FPConfigurationService.GetAllPageSpecificPlaceholderConfig();
            return View(new GridModel(pageSpecificPlaceholderConfigList));
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="TopFrameHTMLTemplateUpload"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="moduleId"></param>
        /// <param name="topFrameHTML"></param>
        /// <param name="leftFrameHTML"></param>
        /// <param name="rightFrameHTML"></param>
        /// <param name="bottomFrameHTML"></param>
        /// <returns></returns>
        public ActionResult SaveTopFrameHTMLTemplate(HttpPostedFileBase TopFrameHTMLTemplateUpload
                                                        , int pageSpecificPlaceholder
                                                        , int pageSpecificPlaceholderId
                                                        , int moduleId
                                                        , string moduleName
                                                        , string topFrameHTML
                                                        , string leftFrameHTML
                                                        , string rightFrameHTML
                                                        , string bottomFrameHTML)
        {
            var postedfileName = SaveTemplate(TopFrameHTMLTemplateUpload, moduleName, SolutionEnums.PageSpecificPlaceholder.Top);
            return SavePageSpecificPlaceHolderConfig(postedfileName
                                                            , pageSpecificPlaceholder
                                                            , pageSpecificPlaceholderId
                                                            , moduleId
                                                            , topFrameHTML
                                                            , leftFrameHTML
                                                            , rightFrameHTML
                                                            , bottomFrameHTML);
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="LeftFrameHTMLTemplateUpload"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="moduleId"></param>
        /// <param name="topFrameHTML"></param>
        /// <param name="leftFrameHTML"></param>
        /// <param name="rightFrameHTML"></param>
        /// <param name="bottomFrameHTML"></param>
        /// <returns></returns>
        public ActionResult SaveLeftFrameHTMLTemplate(HttpPostedFileBase LeftFrameHTMLTemplateUpload
                                                        , int pageSpecificPlaceholder
                                                        , int pageSpecificPlaceholderId
                                                        , int moduleId
                                                        , string moduleName
                                                        , string topFrameHTML
                                                        , string leftFrameHTML
                                                        , string rightFrameHTML
                                                        , string bottomFrameHTML)
        {
            var postedfileName = SaveTemplate(LeftFrameHTMLTemplateUpload, moduleName, SolutionEnums.PageSpecificPlaceholder.Left);
            return SavePageSpecificPlaceHolderConfig(postedfileName
                                                            , pageSpecificPlaceholder
                                                            , pageSpecificPlaceholderId
                                                            , moduleId
                                                            , topFrameHTML
                                                            , leftFrameHTML
                                                            , rightFrameHTML
                                                            , bottomFrameHTML);
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="RightFrameHTMLTemplateUpload"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="moduleId"></param>
        /// <param name="topFrameHTML"></param>
        /// <param name="leftFrameHTML"></param>
        /// <param name="rightFrameHTML"></param>
        /// <param name="bottomFrameHTML"></param>
        /// <returns></returns>
        public ActionResult SaveRightFrameHTMLTemplate(HttpPostedFileBase RightFrameHTMLTemplateUpload
                                                        , int pageSpecificPlaceholder
                                                        , int pageSpecificPlaceholderId
                                                        , int moduleId
                                                        , string moduleName
                                                        , string topFrameHTML
                                                        , string leftFrameHTML
                                                        , string rightFrameHTML
                                                        , string bottomFrameHTML)
        {
            var postedfileName = SaveTemplate(RightFrameHTMLTemplateUpload, moduleName, SolutionEnums.PageSpecificPlaceholder.Right);
            return SavePageSpecificPlaceHolderConfig(postedfileName
                                                            , pageSpecificPlaceholder
                                                            , pageSpecificPlaceholderId
                                                            , moduleId
                                                            , topFrameHTML
                                                            , leftFrameHTML
                                                            , rightFrameHTML
                                                            , bottomFrameHTML);
        }
        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="BottomFrameHTMLTemplateUpload"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="moduleId"></param>
        /// <param name="topFrameHTML"></param>
        /// <param name="leftFrameHTML"></param>
        /// <param name="rightFrameHTML"></param>
        /// <param name="bottomFrameHTML"></param>
        /// <returns></returns>
        public ActionResult SaveBottomFrameHTMLTemplate(HttpPostedFileBase BottomFrameHTMLTemplateUpload
                                                        , int pageSpecificPlaceholder
                                                        , int pageSpecificPlaceholderId
                                                        , int moduleId
                                                        , string moduleName
                                                        , string topFrameHTML
                                                        , string leftFrameHTML
                                                        , string rightFrameHTML
                                                        , string bottomFrameHTML)
        {
            var postedfileName = SaveTemplate(BottomFrameHTMLTemplateUpload, moduleName, SolutionEnums.PageSpecificPlaceholder.Bottom);
            return SavePageSpecificPlaceHolderConfig(postedfileName
                                                            , pageSpecificPlaceholder
                                                            , pageSpecificPlaceholderId
                                                            , moduleId
                                                            , topFrameHTML
                                                            , leftFrameHTML
                                                            , rightFrameHTML
                                                            , bottomFrameHTML);
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="postedfileName"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="moduleId"></param>
        /// <param name="topFrameHTML"></param>
        /// <param name="leftFrameHTML"></param>
        /// <param name="rightFrameHTML"></param>
        /// <param name="bottomFrameHTML"></param>
        /// <returns></returns>
        public JsonResult SavePageSpecificPlaceHolderConfig(string postedfileName
                                                                , int pageSpecificPlaceholder
                                                                , int pageSpecificPlaceholderId
                                                                , int moduleId
                                                                , string topFrameHTML
                                                                , string leftFrameHTML
                                                                , string rightFrameHTML
                                                                , string bottomFrameHTML)
        {
            try
            {
                var pageSpecificPlaceholderConfigVM = new PageSpecificPlaceholderConfigVM();
                pageSpecificPlaceholderConfigVM.Id = pageSpecificPlaceholderId;
                pageSpecificPlaceholderConfigVM.ModuleId = moduleId;
                pageSpecificPlaceholderConfigVM.TopFrameHTML = topFrameHTML;
                pageSpecificPlaceholderConfigVM.LeftFrameHTML = leftFrameHTML;
                pageSpecificPlaceholderConfigVM.RightFrameHTML = rightFrameHTML;
                pageSpecificPlaceholderConfigVM.BottomFrameHTML = bottomFrameHTML;
                pageSpecificPlaceholderConfigVM.IPAddressOfLastAction = CurrentFPApplicationContext.LoggedInUser.IPAddress;

                if (pageSpecificPlaceholderConfigVM.Id == 0)
                {
                    pageSpecificPlaceholderConfigVM.CreatedOn = DateTime.Now;
                    pageSpecificPlaceholderConfigVM.CreatedBy = CurrentFPApplicationContext.LoggedInUser.Username;
                }
                else
                {
                    pageSpecificPlaceholderConfigVM.ModifiedOn = DateTime.Now;
                    pageSpecificPlaceholderConfigVM.ModifiedBy = CurrentFPApplicationContext.LoggedInUser.Username;
                }

                switch ((SolutionEnums.PageSpecificPlaceholder)pageSpecificPlaceholder)
                {
                    case SolutionEnums.PageSpecificPlaceholder.Top:
                        pageSpecificPlaceholderConfigVM.TopFrameHTML = postedfileName;
                        break;
                    case SolutionEnums.PageSpecificPlaceholder.Left:
                        pageSpecificPlaceholderConfigVM.LeftFrameHTML = postedfileName;
                        break;
                    case SolutionEnums.PageSpecificPlaceholder.Right:
                        pageSpecificPlaceholderConfigVM.RightFrameHTML = postedfileName;
                        break;
                    case SolutionEnums.PageSpecificPlaceholder.Bottom:
                        pageSpecificPlaceholderConfigVM.BottomFrameHTML = postedfileName;
                        break;
                }

                int result = _FPConfigurationService.SavePageSpecificPlaceholder(pageSpecificPlaceholderConfigVM);

                return Json(new
                {
                    PageSpecificPlaceholderId = result,
                    TopFrameHTML = pageSpecificPlaceholderConfigVM.TopFrameHTML,
                    LeftFrameHTML = pageSpecificPlaceholderConfigVM.LeftFrameHTML,
                    RightFrameHTML = pageSpecificPlaceholderConfigVM.RightFrameHTML,
                    BottomFrameHTML = pageSpecificPlaceholderConfigVM.BottomFrameHTML,
                    pageSpecificPlaceholder = ((SolutionEnums.PageSpecificPlaceholder)pageSpecificPlaceholder).ToString()
                });

            }
            catch (Exception ex)
            {
                return Json(new { PageSpecificPlaceholderId = -1, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete page specfic place holder
        /// </summary>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <returns></returns>
        public JsonResult Delete(string[] fileNames, int pageSpecificPlaceholderId, int pageSpecificPlaceholder, string moduleName)
        {
            var result = _FPConfigurationService.DeletePageSpecificPlaceholderConfig(pageSpecificPlaceholderId, (SolutionEnums.PageSpecificPlaceholder)pageSpecificPlaceholder);

            if (result)
            {
                DeleteTemplate(moduleName, (SolutionEnums.PageSpecificPlaceholder)pageSpecificPlaceholder);
                return Json(new { IsDelete = true, Success = true, pageSpecificPlaceholder = ((SolutionEnums.PageSpecificPlaceholder)pageSpecificPlaceholder).ToString() });
            }
            else
            {
                return Json(new { IsDelete = true, Success = false });
            }
        }

        #endregion

        #endregion

        #region [Method]

        /// <summary>
        /// Save template to temporary phisical folder
        /// </summary>
        /// <param name="template"></param>
        private string SaveTemplate(HttpPostedFileBase template, string moduleName, SolutionEnums.PageSpecificPlaceholder modulePart)
        {
            string fileName = template.FileName;
            string directoryTemplatePath = Server.MapPath(ConfigurationManager.AppSettings["StaticHtmlPageDirectory"]);

            directoryTemplatePath = Path.Combine(directoryTemplatePath, moduleName, modulePart.ToString());

            if (!Directory.Exists(directoryTemplatePath))
            {
                Directory.CreateDirectory(directoryTemplatePath);
            }

            string templatePath = Path.Combine(directoryTemplatePath, fileName);
            template.SaveAs(templatePath);

            return fileName;
        }

        /// <summary>
        /// Delete template to temporary phisical folder
        /// </summary>
        /// <param name="template"></param>
        private void DeleteTemplate(string moduleName, SolutionEnums.PageSpecificPlaceholder modulePart)
        {
            string directoryTemplatePath = Server.MapPath(ConfigurationManager.AppSettings["StaticHtmlPageDirectory"]);
            directoryTemplatePath = Path.Combine(directoryTemplatePath, moduleName, modulePart.ToString());
            if (Directory.Exists(directoryTemplatePath))
            {
                Directory.Delete(directoryTemplatePath, true);
            }
        }

        /// <summary>
        /// Returns file name without time stamp
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetFileNamewithoutTimeStamp(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                if (fileName.Contains("_"))
                {
                    fileName = fileName.Substring(0, fileName.LastIndexOf("_"));
                }
            }
            return fileName;
        }

        #endregion
    }
}