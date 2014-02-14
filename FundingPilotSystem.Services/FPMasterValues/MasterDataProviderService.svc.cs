using AutoMapper;
using FundingPilotSystem.BLL;
using FundingPilotSystem.BO;
using FundingPilotSystem.Common;
using FundingPilotSystem.VM;
using LoggingFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FundingPilotSystem.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MasterDataProviderService : IMasterDataProviderService
    {
        private MasterDataBLL _masterDataBusinessLogic = null;
        private FPApplication FPApplication { get; set; }

        public void SetFPApplication(FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this._masterDataBusinessLogic = new MasterDataBLL(this.FPApplication);
        }
        public MasterDataProviderService()
        {

        }

        /// <summary>
        ///  call to get list of countries
        /// </summary>
        /// <returns></returns>
        public List<CountryListVM> GetCountries()
        {
            Log4NetLogger.Info("Services : In GetCountries");
            Mapper.CreateMap<CountryListBO, CountryListVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetCountries(), new List<CountryListVM>());

        }

        /// <summary>
        ///  call to get list of account opening fields
        /// </summary>
        /// <returns></returns>
        public List<AccountOpeningFieldVM> GetAccountOpeningFields()
        {
            Mapper.CreateMap<AccountOpeningFieldBO, AccountOpeningFieldVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetAccountOpeningFields(), new List<AccountOpeningFieldVM>());
        }

        /// <summary>
        ///  call to Get list of company industries 
        /// </summary>
        /// <returns></returns>
        /// 
        public List<CompanyIndustryListVM> GetCompanyIndustries()
        {
            Mapper.CreateMap<CompanyIndustryListBO, CompanyIndustryListVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetCompanyIndustries(), new List<CompanyIndustryListVM>());

        }

        /// <summary>
        ///   call to Get list of Country Of Operations
        /// </summary>
        /// <returns></returns>
        /// 
        public List<CountryOfOperationVM> GetCountryOfOperations()
        {
            Mapper.CreateMap<CountryOfOperationBO, CountryOfOperationVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetCountryOfOperations(), new List<CountryOfOperationVM>());
        }

        /// <summary>
        ///  call to  Get list of KYCStatus
        /// </summary>
        /// <returns></returns>
        /// 
        public List<KYCStatusVM> GetKYCStatus()
        {
            Mapper.CreateMap<KYCStatusBO, KYCStatusVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetKYCStatus(), new List<KYCStatusVM>());

        }

        /// <summary>
        ///  call to Get list of Public Authority Industry
        /// </summary>
        /// <returns></returns>
        /// 
        public List<PublicAuthorityIndustryListVM> GetPublicAuthorityIndustries()
        {
            Mapper.CreateMap<PublicAuthorityIndustryListBO, PublicAuthorityIndustryListVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetPublicAuthorityIndustries(), new List<PublicAuthorityIndustryListVM>());

        }

        /// <summary>
        ///  call to  Get list of Supported AccountType
        /// </summary>
        /// <returns></returns>
        /// 
        public List<SupportedAccountTypeVM> GetSupportedAccountType()
        {
            Mapper.CreateMap<SupportedAccountTypeBO, SupportedAccountTypeVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetSupportedAccountType(), new List<SupportedAccountTypeVM>());

        }

        /// <summary>
        /// Get list of Supported Currencies
        /// </summary>
        /// <returns></returns>
        /// 
        public List<SupportedCurrencyVM> GetSupportedCurrencies()
        {
            Mapper.CreateMap<SupportedCurrencyBO, SupportedCurrencyVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetSupportedCurrencies(), new List<SupportedCurrencyVM>());
        }

        /// <summary>
        /// Get list of Supported Languages
        /// </summary>
        /// <returns></returns>
        /// 
        public List<SupportedLanguageVM> GetSupportedLanguages()
        {
            Mapper.CreateMap<SupportedLanguageBO, SupportedLanguageVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetSupportedLanguages(), new List<SupportedLanguageVM>());
        }

        /// <summary>
        /// Get list of SystemModules
        /// </summary>
        /// <returns></returns>
        /// 
        public List<SystemModuleVM> GetSystemModules()
        {
            Mapper.CreateMap<SystemModuleBO, SystemModuleVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetSystemModules(), new List<SystemModuleVM>());
        }

        /// <summary>
        /// Get list of User Statuses
        /// </summary>
        /// <returns></returns>
        /// 
        public List<UserStatusVM> GetUserStatuses()
        {
            Mapper.CreateMap<UserStatusBO, UserStatusVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetUserStatuses(), new List<UserStatusVM>());
        }

        /// <summary>
        /// Get list of UserTypes
        /// </summary>
        /// <returns></returns>
        /// 
        public List<UserTypeVM> GetUserTypes()
        {
            Mapper.CreateMap<UserTypeBO, UserTypeVM>();
            return Mapper.Map(_masterDataBusinessLogic.GetUserTypes(), new List<UserTypeVM>());
        }

    }
}
