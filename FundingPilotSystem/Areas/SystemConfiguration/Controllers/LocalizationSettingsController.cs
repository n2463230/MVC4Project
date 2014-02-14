using AutoMapper;
using FundingPilotSystem.Common;
using FundingPilotSystem.Controllers;
using FundingPilotSystem.Services.MasterDataProviderService;
using FundingPilotSystem.Utilities;
using FundingPilotSystem.VM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web.Mvc;
using System.Xml.Linq;
using Telerik.Web.Mvc;

namespace FundingPilotSystem.Areas.SystemConfiguration.Controllers
{
    /// <summary>
    /// Class used for System Configuration for localization
    /// </summary>
    public class LocalizationSettingsController : BaseController
    {
        #region [Declaration]

        private IMasterDataProviderService _masterDataProviderService;

        #endregion

        #region [Constructor]

        public LocalizationSettingsController()
        {
            this._masterDataProviderService = ServiceReferences.GetMasterProviderServiceClient();
        }

        #endregion

        #region [Action]

        /// <summary>
        /// Change Resource method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeResource()
        {
            LoggingFramework.Log4NetLogger.Info("UI: In Areas/SystemConfiguration/LocalizationSettings/ChangeResource");

            LocalizationSettingsVM localizationSettingsVm = new LocalizationSettingsVM();
            var systemModule = _masterDataProviderService.GetSystemModules();

            var mappedValues = Mapper.CreateMap<SystemModuleVM, SelectListItem>()
                                      .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString(CultureInfo.InvariantCulture)))
                                      .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Module));

            localizationSettingsVm.SystemModuleDDL = Mapper.Map<List<SystemModuleVM>, List<SelectListItem>>(systemModule);
            localizationSettingsVm.SystemModuleDDL.Insert(0, new SelectListItem { Text = CustomLocalizationUtility.GetKeyValue("CommonResource", "Select"), Value = "0" });

            localizationSettingsVm.Cultures = CommonUtility.GetCultures();
            localizationSettingsVm.Cultures.Insert(0, new SelectListItem { Text = CustomLocalizationUtility.GetKeyValue("CommonResource", "Select"), Value = "0" });

            return View(localizationSettingsVm);
        }

        /// <summary>
        /// Ajax method to load the data in the grid from the resource file
        /// </summary>
        /// <param name="selectedModule"></param>
        /// <param name="selectedCulture"></param>
        /// <returns></returns>
        [GridAction]
        public ActionResult ListResourceAjax(string selectedCulture, string moduleId)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}-{2}", "UI: In Areas/SystemConfiguration/LocalizationSettings/ListResourceAjax", selectedCulture, moduleId));
            var moduleResourceData = new List<ResourceDataVM>();
            if (!String.IsNullOrEmpty(moduleId) && !String.IsNullOrEmpty(selectedCulture))
            {
                string sResxPath = GetResourceFilePath(moduleId, selectedCulture);
                if (!System.IO.File.Exists(sResxPath))
                {
                    return View(new GridModel(moduleResourceData));
                }
                moduleResourceData = GetResourceData(sResxPath, moduleId, selectedCulture);
            }
            return View(new GridModel(moduleResourceData));
        }

        /// <summary>
        /// Check is resource file exists or not
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        [HttpPost]
        public string CheckIsResourceFileExists(string culture, string moduleId)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}-{2}", "UI: In Areas/SystemConfiguration/LocalizationSettings/CheckIsResourceFileExists", culture, moduleId));
            string sResxPath = GetResourceFilePath(moduleId, culture);
            if (!System.IO.File.Exists(sResxPath))
            {
                return "NOTFOUND"; // when file not found 
            }
            else
            {
                return "FOUND"; // when file found 
            }
        }

        /// <summary>
        /// Create a new resource file from a default file
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        [HttpPost]
        public string CreateNewResourceFile(string culture, string moduleId)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}-{2}", "UI: In Areas/SystemConfiguration/LocalizationSettings/CreateNewResourceFile", culture, moduleId));
            string defaultResourcePath = GetResourceFilePath(moduleId, CommonUtility.DefaultCulture);
            if (!String.IsNullOrEmpty(defaultResourcePath))
            {
                if (System.IO.File.Exists(defaultResourcePath))
                {
                    XDocument doc = XDocument.Load(defaultResourcePath);
                    string newFileName = defaultResourcePath.Replace(CommonUtility.DefaultCulture, culture);
                    doc.Save(newFileName);
                    return "FC"; // file changed
                }
            }
            return "DFNF"; // default file not found
        }

        /// <summary>
        /// Save the data changed in the grid inline in the resource file back
        /// </summary>
        /// <param name="updatedR esources"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult SaveResources([Bind(Prefix = "updated")]IEnumerable<ResourceDataVM> updatedResources)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}", "UI: In Areas/SystemConfiguration/LocalizationSettings/SaveResources", updatedResources));

            var updatedResource = updatedResources.FirstOrDefault();

            string selectedModule = Convert.ToString(updatedResource.ModuleId);
            string selectedCulture = updatedResource.CultureValue;

            string sResxPath = GetResourceFilePath(selectedModule, selectedCulture);
            Hashtable data = new Hashtable();
            foreach (var resource in updatedResources)
            {
                data.Add(resource.Key, resource.NewValue);
            }
            UpdateResourceFile(data, sResxPath);
            var moduleResourceData = GetResourceData(sResxPath, selectedModule, selectedCulture);
            return View(new GridModel(moduleResourceData));
        }

        #endregion

        #region [Method]

        /// <summary>
        /// Get the resource file path for a module and culture
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="selectedCulture"></param>
        /// <returns></returns>
        internal string GetResourceFilePath(string moduleId, string selectedCulture)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}-{2}", "UI: In Areas/SystemConfiguration/LocalizationSettings/GetResourceFilePath", moduleId, selectedCulture));
            string defaultResourceFilePath = GetResourceFilePath(moduleId);
            return defaultResourceFilePath.Replace(CommonUtility.DefaultCulture, selectedCulture);
        }

        /// <summary>
        /// Get the module name by moduleId
        /// </summary>
        /// <param name="ModuleId"></param>
        /// <returns></returns>
        internal string GetResourceFilePath(string moduleId)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}", "UI: In Areas/SystemConfiguration/LocalizationSettings/GetModuleName", moduleId));
            var _masterDataProviderService = ServiceReferences.GetMasterProviderServiceClient();

            if (CacheManager.SystemModuleVMList == null)
            {
                CacheManager.SystemModuleVMList = _masterDataProviderService.GetSystemModules();
            }

            int intModuleId;
            int.TryParse(moduleId, out intModuleId);

            if (intModuleId > 0)
            {
                var module = CacheManager.SystemModuleVMList.Where(s => s.Id == intModuleId).SingleOrDefault();

                if (module != null)
                {
                    var serverPath = System.Web.HttpContext.Current.Server.MapPath("~\\App_LocalResources\\");
                    return System.IO.Path.Combine(serverPath, module.ResourceFolderName, module.ResourceFileName);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// get all the values from the resource file 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        internal List<ResourceDataVM> GetResourceData(string path, string moduleId, string selectedCulture)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}-{2}-{3}", "UI: In Areas/SystemConfiguration/LocalizationSettings/GetResourceData", path, moduleId, selectedCulture));
            List<ResourceDataVM> resourceData = new List<ResourceDataVM>();
            string selectedCultureResourceFilePath = GetResourceFilePath(moduleId, selectedCulture);
            if (System.IO.File.Exists(path))
            {
                ResXResourceReader reader = new ResXResourceReader(path);
                if (reader != null)
                {
                    IDictionaryEnumerator id = reader.GetEnumerator();
                    foreach (DictionaryEntry d in reader)
                    {
                        resourceData.Add(new ResourceDataVM
                        {
                            Key = Convert.ToString(d.Key),
                            Value = GetResourceDataByKey(selectedCultureResourceFilePath, Convert.ToString(d.Key)).Value,
                            NewValue = Convert.ToString(d.Value),
                            ModuleName = moduleId,
                            ModuleId = Convert.ToInt32(moduleId),
                            CultureValue = selectedCulture
                        });
                    } reader.Close();
                }

            }
            return resourceData.OrderBy(o => o.Key).ToList();
        }

        /// <summary>
        /// Get the resource value from a resource file by the key
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        internal ResourceDataVM GetResourceDataByKey(string path, string key)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}-{2}", "UI: In Areas/SystemConfiguration/LocalizationSettings/GetResourceDataByKey", path, key));
            ResourceDataVM resourceData = new ResourceDataVM();
            ResXResourceReader reader = new ResXResourceReader(path);
            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    if (Convert.ToString(d.Key) == key)
                    {
                        resourceData.Key = Convert.ToString(d.Key);
                        resourceData.Value = Convert.ToString(d.Value);
                        resourceData.NewValue = Convert.ToString(d.Value);
                        reader.Close();
                    }
                }
            }
            return resourceData;

        }

        /// <summary>
        /// Method to update the resource text directly
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public void UpdateResourceFile(Hashtable data, String path)
        {
            LoggingFramework.Log4NetLogger.Info(string.Format("{0}-{1}-{2}", "UI: In Areas/SystemConfiguration/LocalizationSettings/UpdateResourceFile", data, path));
            Hashtable resourceEntries = new Hashtable();
            //Get existing resources
            ResXResourceReader reader = new ResXResourceReader(path);
            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    if (d.Value == null)
                        resourceEntries.Add(Convert.ToString(d.Key), "");
                    else
                        resourceEntries.Add(Convert.ToString(d.Key), Convert.ToString(d.Value));
                } reader.Close();
            }
            //Modify resources here...
            foreach (String key in data.Keys)
            {
                if (!resourceEntries.ContainsKey(key))
                {
                    String value = Convert.ToString(data[key]);
                    if (value == null)
                        value = "";
                    resourceEntries.Add(key, value);
                }
                else
                {
                    String value = Convert.ToString(data[key]);
                    if (value == null)
                        value = "";
                    resourceEntries.Remove(key);
                    resourceEntries.Add(key, Convert.ToString(data[key]));
                }
            }
            //Write the combined resource file
            ResXResourceWriter resourceWriter = new ResXResourceWriter(path);
            foreach (String key in resourceEntries.Keys)
            {
                resourceWriter.AddResource(key, resourceEntries[key]);
            }
            resourceWriter.Generate();
            resourceWriter.Close();
        }

        #endregion
    }
}
