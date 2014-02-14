using FundingPilotSystem.Common;
using FundingPilotSystem.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace FundingPilotSystem.Utilities
{
    public static class CacheManager
    {
        private static List<CountryListVM> _countryList;
        public static List<CountryListVM> CountryList
        {
            get
            {
                if (HttpContext.Current.Cache.Get("CacheManager.CountryList") == null)
                {
                    _countryList = null;
                }
                else
                {
                    _countryList = (List<CountryListVM>)HttpContext.Current.Cache.Get("CacheManager.CountryList");
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

        private static List<CountryOfOperationVM> _countryOfOperationList;
        public static List<CountryOfOperationVM> CountryOfOperationList
        {
            get
            {
                if (HttpContext.Current.Cache.Get("CacheManager.CountryOfOperationList") == null)
                {
                    _countryOfOperationList = null;
                }
                else
                {
                    _countryOfOperationList = (List<CountryOfOperationVM>)HttpContext.Current.Cache.Get("CacheManager.CountryOfOperationList");
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

        private static List<SystemModuleVM> _systemModuleVMList;
        public static List<SystemModuleVM> SystemModuleVMList
        {
            get
            {
                if (HttpContext.Current.Cache.Get("CacheManager.SystemModuleVMList") == null)
                {
                    _systemModuleVMList = null;
                }
                else
                {
                    _systemModuleVMList = (List<SystemModuleVM>)HttpContext.Current.Cache.Get("CacheManager.SystemModuleVMList");
                }

                return _systemModuleVMList;
            }
            set
            {
                _systemModuleVMList = value;
                HttpContext.Current.Cache.Remove("CacheManager.SystemModuleVMList");
                HttpContext.Current.Cache.Add("CacheManager.SystemModuleVMList", _systemModuleVMList, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }
        }

        private static List<ProcessEmailTemplateVM> _processEmailTemplateVMList;
        public static List<ProcessEmailTemplateVM> ProcessEmailTemplateVMList
        {
            get
            {
                if (HttpContext.Current.Cache.Get("CacheManager.ProcessEmailTemplateVMList") == null)
                {
                    _processEmailTemplateVMList = null;
                }
                else
                {
                    _processEmailTemplateVMList = (List<ProcessEmailTemplateVM>)HttpContext.Current.Cache.Get("CacheManager.ProcessEmailTemplateVMList");
                }

                return _processEmailTemplateVMList;
            }
            set
            {
                _processEmailTemplateVMList = value;
                HttpContext.Current.Cache.Remove("CacheManager.ProcessEmailTemplateVMList");
                HttpContext.Current.Cache.Add("CacheManager.ProcessEmailTemplateVMList", _processEmailTemplateVMList, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0), CacheItemPriority.Normal, null);
            }
        }        
    }
}