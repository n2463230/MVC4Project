using FundingPilotSystem.Domain.FPMasterValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace FundingPilotSystem.Utilities
{
    public static class CacheManager
    {
        private static List<tblCountryListDto> _countryList;
        public static List<tblCountryListDto> CountryList
        {
            get
            {
                if (HttpContext.Current.Cache.Get("CacheManager.CountryList") == null)
                {
                    _countryList = null;
                }
                else
                {
                    _countryList = (List<tblCountryListDto>)HttpContext.Current.Cache.Get("CacheManager.CountryList");
                }

                return _countryList;
            }
            set
            {
                _countryList = value;
                HttpContext.Current.Cache.Remove("CacheManager.CountryList");
                HttpContext.Current.Cache.Add("CacheManager.CountryList", _countryList, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }
        }

        private static List<tblCountryOfOperationDto> _countryOfOperationList;
        public static List<tblCountryOfOperationDto> CountryOfOperationList
        {
            get
            {
                if (HttpContext.Current.Cache.Get("CacheManager.CountryOfOperationList") == null)
                {
                    _countryOfOperationList = null;
                }
                else
                {
                    _countryOfOperationList = (List<tblCountryOfOperationDto>)HttpContext.Current.Cache.Get("CacheManager.CountryOfOperationList");
                }

                return _countryOfOperationList;
            }
            set
            {
                _countryOfOperationList = value;
                HttpContext.Current.Cache.Remove("CacheManager.CountryOfOperationList");
                HttpContext.Current.Cache.Add("CacheManager.CountryOfOperationList", _countryOfOperationList, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }
        }
    }
}