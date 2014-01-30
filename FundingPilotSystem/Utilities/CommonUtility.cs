using FundingPilotSystem.Domain.FPMasterValues;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Web;
using System.Web.WebPages.Html;
using SelectListItem = System.Web.Mvc.SelectListItem;
using FundingPilotSystem.Services.FPMasterValues.MasterDataProviderService;
namespace FundingPilotSystem.Utilities
{
    public static class CommonUtility
    {
        /// <summary>
        /// Common function to get the countries from service or from cache if available
        /// </summary>
        /// <returns></returns>
        internal static List<tblCountryListDto> GetCountries(IMasterDataProviderService _masterProviderService)
        {
            List<tblCountryListDto> countries = new List<tblCountryListDto>();
            if (CacheManager.CountryList == null)
            {

                countries = _masterProviderService.GetCountries();
                CacheManager.CountryList = countries;
            }
            else
            {
                countries = CacheManager.CountryList;
            }
            return countries;
        }

        /// <summary>
        /// Common function to get the countries of operations
        /// </summary>
        /// <returns></returns>
        internal static List<tblCountryOfOperationDto> GetCountriesOfOperation(IMasterDataProviderService _masterProviderService)
        {
            List<tblCountryOfOperationDto> countries = new List<tblCountryOfOperationDto>();
            if (CacheManager.CountryList == null)
            {

                countries = _masterProviderService.GetCountryOfOperations();
                CacheManager.CountryOfOperationList = countries;
            }
            else
            {
                countries = CacheManager.CountryOfOperationList;
            }
            return countries;
        }

    }
}