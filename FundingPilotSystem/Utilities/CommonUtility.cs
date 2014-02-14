using AutoMapper;
using FundingPilotSystem.Common;
using FundingPilotSystem.Services.MasterDataProviderService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using CountryListVM = FundingPilotSystem.VM.CountryListVM;
using CountryOfOperationVM = FundingPilotSystem.VM.CountryOfOperationVM;
using System.Linq;

namespace FundingPilotSystem.Utilities
{
    public static class CommonUtility
    {

        public static string ApplicationLocalResourcePath
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ApplicationLocalResourcePath"].ToString());
            }
        }

        public static string DefaultCulture
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["DefaultCulture"].ToString());
            }
        }
        /// <summary>
        /// Common function to get the countries from service or from cache if available
        /// </summary>
        /// <returns></returns>
        internal static List<CountryListVM> GetCountries(IMasterDataProviderService _masterProviderService)
        {
            List<CountryListVM> countries = new List<CountryListVM>();
            if (CacheManager.CountryList == null)
            {
                Mapper.CreateMap<CountryListVM, CountryListVM>();
                countries = Mapper.Map(_masterProviderService.GetCountries(), countries);
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
        internal static List<CountryOfOperationVM> GetCountriesOfOperation(IMasterDataProviderService _masterProviderService)
        {
            List<CountryOfOperationVM> countries = new List<CountryOfOperationVM>();
            if (CacheManager.CountryOfOperationList == null)
            {
                Mapper.CreateMap<CountryOfOperationVM, CountryOfOperationVM>();
                countries = Mapper.Map(_masterProviderService.GetCountryOfOperations(), countries);
                CacheManager.CountryOfOperationList = countries;
            }
            else
            {
                countries = CacheManager.CountryOfOperationList;
            }
            return countries;
        }
        /// <summary>
        /// Set the current culture of the page
        /// </summary>
        /// <param name="culture"></param>
        internal static void SetCurrentCulture(string culture)
        {
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        /// <summary>
        /// list all the cultures
        /// </summary>
        /// <returns></returns>
        internal static List<SelectListItem> GetCultures()
        {
            List<SelectListItem> cultures = new List<SelectListItem>();
            var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures).OrderBy(c => c.EnglishName);

            return (from info in allCultures
                    select new SelectListItem
                     {
                         Text = info.EnglishName,
                         Value = info.TextInfo.CultureName
                     }).ToList();
        }
    }
}