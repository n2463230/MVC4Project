using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.Common;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;
using LoggingFramework;
using System;
using System.Collections.Generic;
using FundingPilotSystem.Common;
namespace FundingPilotSystem.DAL
{

    /// <summary>
    /// This class provides master data
    /// </summary>
    public class MasterDataProviderDAL
    {
        #region [Declaration]

        private FPApplication FPApplication { get; set; }
        MasterDataProvider masterDataProvider;
        #endregion

        public MasterDataProviderDAL(FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this.masterDataProvider = new MasterDataProvider(fpApplication);

        }

        /// <summary>
        /// Get list of countries
        /// </summary>
        /// <returns></returns>
        public List<CountryListBO> GetCountries()
        {
            Log4NetLogger.Info("DAL : In GetCountries");
            Mapper.CreateMap<tblCountryListDto, CountryListBO>();
            return Mapper.Map(masterDataProvider.GetCountries(), new List<CountryListBO>());
        }

        /// <summary>
        /// Get list of account opening fields
        /// </summary>
        /// <returns></returns>
        public List<AccountOpeningFieldBO> GetAccountOpeningFields()
        {
            Mapper.CreateMap<tblAccountOpeningFieldDto, AccountOpeningFieldBO>();
            return Mapper.Map(masterDataProvider.GetAccountOpeningFields(), new List<AccountOpeningFieldBO>());

        }

        /// <summary>
        /// Get list of company insdustries 
        /// </summary>
        /// <returns></returns>
        public List<CompanyIndustryListBO> GetCompanyIndustries()
        {
            Mapper.CreateMap<tblCompanyIndustryListDto, CompanyIndustryListBO>();
            return Mapper.Map(masterDataProvider.GetCompanyIndustries(), new List<CompanyIndustryListBO>());
        }

        /// <summary>
        /// Get list of Country Of Operations
        /// </summary>
        /// <returns></returns>
        public List<CountryOfOperationBO> GetCountryOfOperations()
        {
            Mapper.CreateMap<tblCountryOfOperationDto, CountryOfOperationBO>();
            return Mapper.Map(masterDataProvider.GetCountryOfOperations(), new List<CountryOfOperationBO>());
        }

        /// <summary>
        /// Get list of KYCStatus
        /// </summary>
        /// <returns></returns>
        public List<KYCStatusBO> GetKYCStatus()
        {
            Mapper.CreateMap<tblKYCStatusDto, KYCStatusBO>();
            return Mapper.Map(masterDataProvider.GetKYCStatus(), new List<KYCStatusBO>());
        }

        /// <summary>
        /// Get list of Public Authority Industry
        /// </summary>
        /// <returns></returns>
        public List<PublicAuthorityIndustryListBO> GetPublicAuthorityIndustries()
        {
            Mapper.CreateMap<tblPublicAuthorityIndustryListDto, PublicAuthorityIndustryListBO>();
            return Mapper.Map(masterDataProvider.GetPublicAuthorityIndustries(), new List<PublicAuthorityIndustryListBO>());
        }

        /// <summary>
        /// Get list of Supported AccountType
        /// </summary>
        /// <returns></returns>
        public List<SupportedAccountTypeBO> GetSupportedAccountType()
        {
            Mapper.CreateMap<tblSupportedAccountTypeDto, SupportedAccountTypeBO>();
            return Mapper.Map(masterDataProvider.GetSupportedAccountType(), new List<SupportedAccountTypeBO>());
        }

        /// <summary>
        /// Get list of Supported Currencies
        /// </summary>
        /// <returns></returns>
        public List<SupportedCurrencyBO> GetSupportedCurrencies()
        {
            Mapper.CreateMap<tblSupportedCurrencyDto, SupportedCurrencyBO>();
            return Mapper.Map(masterDataProvider.GetSupportedCurrencies(), new List<SupportedCurrencyBO>());
        }

        /// <summary>
        /// Get list of Supported Languages
        /// </summary>
        /// <returns></returns>
        public List<SupportedLanguageBO> GetSupportedLanguages()
        {
            Mapper.CreateMap<tblSupportedLanguageDto, SupportedLanguageBO>();
            return Mapper.Map(masterDataProvider.GetSupportedLanguages(), new List<SupportedLanguageBO>());
        }

        /// <summary>
        /// Get list of SystemModules
        /// </summary>
        /// <returns></returns>
        public List<SystemModuleBO> GetSystemModules()
        {
            Mapper.CreateMap<tblSystemModuleDto, SystemModuleBO>();
            return Mapper.Map(masterDataProvider.GetSystemModules(), new List<SystemModuleBO>());

        }

        /// <summary>
        /// Get list of User Statuses
        /// </summary>
        /// <returns></returns>
        public List<UserStatusBO> GetUserStatuses()
        {
            Mapper.CreateMap<tblUserStatusDto, UserStatusBO>();
            return Mapper.Map(masterDataProvider.GetUserStatuses(), new List<UserStatusBO>());
        }

        /// <summary>
        /// Get list of UserTypes
        /// </summary>
        /// <returns></returns>
        public List<UserTypeBO> GetUserTypes()
        {
            Mapper.CreateMap<tblUserTypeDto, UserTypeBO>();
            return Mapper.Map(masterDataProvider.GetUserTypes(), new List<UserTypeBO>());
        }
    }
}
