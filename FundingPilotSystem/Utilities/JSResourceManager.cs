using FundingPilotSystem.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FundingPilotSystem.Utilities
{
    public class JSResourceManager
    {

        /// <summary>
        /// Getting an item from the resource 
        /// </summary>
        /// <param name="resourceManager"></param>
        /// <returns></returns>
        public static JavaScriptResult GetResourceScript(string pageName)
        {
            JavaScriptResult javaScriptResult = CreateResourceScript(pageName);

            return javaScriptResult;
        }

        private static JavaScriptResult CreateResourceScript(string pageName)
        {
            string sResxPath = CustomLocalizationUtility.GetResourceFilePath(pageName, 
                                            Convert.ToString(HttpContext.Current.Session["CurrentCulture"]));
            
            var resourceData = CustomLocalizationUtility.GetResourceData(sResxPath, pageName);

            StringBuilder sb = new StringBuilder();
            //sb.Append(pageName);
            sb.Append(string.Format("{0}",pageName));
            sb.Append("={");
            foreach (var resource in resourceData)
            {

                sb.AppendFormat("\"{0}\":\"{1}\",", resource.Key, EncodeValue(resource.NewValue));
            }

            string script = sb.ToString();
            if (!string.IsNullOrEmpty(script))
                script = script.Remove(script.Length - 1);

            script += "};";

            JavaScriptResult result = new JavaScriptResult { Script = script };
            return result;
        }
        /// <summary>
        /// Encoding the values
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static string EncodeValue(string value)
        {
            value = (value).Replace("\"", "\\\"").Replace('{', '[').Replace('}', ']');
            value = value.Trim();
            value = RemoveWhiteSpace(value);
            return value;
        }
        /// <summary>
        /// method removing white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static string RemoveWhiteSpace(string value)
        {
            return System.Text.RegularExpressions.Regex.Replace(value, @"\s", " ");
        }

    }
}