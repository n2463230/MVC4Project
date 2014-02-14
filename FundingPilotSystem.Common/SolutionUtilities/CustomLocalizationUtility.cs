
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FundingPilotSystem.Common
{
    public class SystemModule
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string ResourceFileName { get; set; }
        public string ResourceFolderName { get; set; }
    }

    public static class CustomLocalizationUtility
    {
        public static List<SystemModule> SystemModuleList { get; set; }

        /// <summary>
        /// function to get the value from the resource for a key in Views
        /// </summary>
        /// <param name="currentContext"></param>
        /// <param name="resourceFileName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetKeyValue(HttpContext currentContext, string resourceFileName, string keyName)
        {
            string keyValue = "";
            string sResxPath = GetResourceFilePath(resourceFileName, CultureInfo.CurrentCulture.Name);
            if (!File.Exists(sResxPath))
            {
                sResxPath = sResxPath.Replace(CultureInfo.CurrentCulture.Name, "en-IN");
            }
            using (ResXResourceSet resxSet = new ResXResourceSet(sResxPath))
            {
                keyValue = resxSet.GetString(keyName);
            }
            return keyValue;
        }

        /// <summary>
        /// function to get the value from the resource for a key in Views
        /// </summary>
        /// <param name="currentContext"></param>
        /// <param name="resourceFileName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetKeyValue(string resourceFileName, string keyName)
        {
            string keyValue = "";

            string sResxPath = GetResourceFilePath(resourceFileName, CultureInfo.CurrentCulture.Name);
            if (!File.Exists(sResxPath))
            {
                sResxPath = sResxPath.Replace(CultureInfo.CurrentCulture.Name, "en-IN");
            }

            using (ResXResourceSet resxSet = new ResXResourceSet(sResxPath))
            {
                keyValue = resxSet.GetString(keyName);
            }

            return keyValue;
        }

        /// <summary>
        /// Get the resource file path for a module and culture
        /// </summary>
        /// <param name="SelectedModule"></param>
        /// <param name="SelectedCulture"></param>
        /// <returns></returns>
        public static string GetResourceFilePath(string resourceFileName, string SelectedCulture)
        {
            string ServerPath = HttpContext.Current.Server.MapPath("~\\App_LocalResources\\" + GetFolderName(resourceFileName));

            var sResxPath = string.Format("{0}{1}.{2}{3}", ServerPath + "\\", resourceFileName, SelectedCulture, ".resx");
            if (!File.Exists(sResxPath))
            {
                sResxPath = sResxPath.Replace(CultureInfo.CurrentCulture.Name, "en-IN");
            }

            return sResxPath;

        }

        /// <summary>
        /// Get the module name by moduleId
        /// </summary>
        /// <param name="ModuleId"></param>
        /// <returns></returns>
        internal static string GetModuleName(int ModuleId)
        {
            return SystemModuleList.Where(s => s.Id == ModuleId).Single().ResourceFileName;
        }

        /// <summary>
        /// Get the module name by moduleId
        /// </summary>
        /// <param name="ModuleId"></param>
        /// <returns></returns>
        internal static string GetFolderName(string resourceFileName)
        {
            return SystemModuleList.Where(s => s.ResourceFileName.ToLower().StartsWith(resourceFileName.ToLower())).FirstOrDefault().ResourceFolderName;
        }

        /// <summary>
        /// get all the values from the resource file 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public static List<ResourceData> GetResourceData(string path, string moduleName)
        {
            List<ResourceData> resourceData = new List<ResourceData>();
            string defaultLanguagePath = GetResourceFilePath(moduleName, "en-IN");
            if (File.Exists(path))
            {

                ResXResourceReader reader = new ResXResourceReader(path);
                if (reader != null)
                {
                    IDictionaryEnumerator id = reader.GetEnumerator();
                    foreach (DictionaryEntry d in reader)
                    {
                        resourceData.Add(new ResourceData
                        {
                            Key = d.Key.ToString(),
                            Value = GetResourceDataByKey(defaultLanguagePath, d.Key.ToString()).Value,
                            NewValue = d.Value.ToString(),
                            ModuleName = moduleName
                        });
                    } reader.Close();
                }

            }
            return resourceData;
        }

        /// <summary>
        /// Get the resource value from a resource file by the key
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static ResourceData GetResourceDataByKey(string path, string key)
        {
            ResourceData resourceData = new ResourceData();
            ResXResourceReader reader = new ResXResourceReader(path);
            if (reader != null)
            {
                IDictionaryEnumerator id = reader.GetEnumerator();
                foreach (DictionaryEntry d in reader)
                {
                    if (d.Key.ToString() == key)
                    {
                        resourceData.Key = d.Key.ToString();
                        resourceData.Value = d.Value.ToString();
                        resourceData.NewValue = d.Value.ToString();
                        reader.Close();
                    }
                }
            }
            return resourceData;

        }
    }
}
