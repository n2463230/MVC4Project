using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace FundingPilotSystem.Services.Utilities
{
    public static class CommonFunctions
    {
        /// <summary>
        /// Method used to set the return type of current incoming request
        /// </summary>
        public static void SetReturnTypeForCalledMethod()
        {
            string formatQueryStringValue = WebOperationContext.Current.IncomingRequest.Accept;
            if (!string.IsNullOrEmpty(formatQueryStringValue))
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
                if (formatQueryStringValue.Contains("xml"))
                {
                    WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
                }
                else if (formatQueryStringValue.Contains("json"))
                {
                    WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
                }

            }
        }
    }
}