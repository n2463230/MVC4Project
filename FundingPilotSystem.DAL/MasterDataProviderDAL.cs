using FundingPilotSystem.Domain.FPMasterValues;
using FundingPilotSystem.Domain.SolutionDto;
using FundingPilotSystem.UnifiedDataStore.DataProviders;
using LoggingFramework;
using System;
using System.Collections.Generic;

namespace FundingPilotSystem.DAL
{
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
        public List<tblCountryListDto> GetCountries()
        {
            Log4NetLogger.Info("DAL : In GetCountries");
            return masterDataProvider.GetCountries();
        }

        /// <summary>
        /// Get list of account opening fields
        /// </summary>
        /// <returns></returns>
        public List<tblAccountOpeningFieldDto> GetAccountOpeningFields()
        {
            return masterDataProvider.GetAccountOpeningFields();
        }
        /// <summary>
        /// Get list of company insdustries 
        /// </summary>
        /// <returns></returns>
        public List<tblCompanyIndustryListDto> GetCompanyIndustries()
        {
            return masterDataProvider.GetCompanyIndustries();
        }

        /// <summary>
        /// Get list of Country Of Operations
        /// </summary>
        /// <returns></returns>
        public List<tblCountryOfOperationDto> GetCountryOfOperations()
        {
            return masterDataProvider.GetCountryOfOperations();
        }

        /// <summary>
        /// Get list of KYCStatus
        /// </summary>
        /// <returns></returns>
        public List<tblKYCStatusDto> GetKYCStatus()
        {
            return masterDataProvider.GetKYCStatus();
        }

        /// <summary>
        /// Get list of Public Authority Industry
        /// </summary>
        /// <returns></returns>
        public List<tblPublicAuthorityIndustryListDto> GetPublicAuthorityIndustries()
        {
            return masterDataProvider.GetPublicAuthorityIndustries();
        }

        /// <summary>
        /// Get list of Supported AccountType
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedAccountTypeDto> GetSupportedAccountType()
        {
            return masterDataProvider.GetSupportedAccountType();
        }

        /// <summary>
        /// Get list of Supported Currencies
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedCurrencyDto> GetSupportedCurrencies()
        {
            return masterDataProvider.GetSupportedCurrencies();
        }

        /// <summary>
        /// Get list of Supported Languages
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedLanguageDto> GetSupportedLanguages()
        {
            return masterDataProvider.GetSupportedLanguages();
        }

        /// <summary>
        /// Get list of SystemModules
        /// </summary>
        /// <returns></returns>
        public List<tblSystemModuleDto> GetSystemModules()
        {
            return masterDataProvider.GetSystemModules();
        }

        /// <summary>
        /// Get list of User Statuses
        /// </summary>
        /// <returns></returns>
        public List<tblUserStatusDto> GetUserStatuses()
        {
            return masterDataProvider.GetUserStatuses();
        }

        /// <summary>
        /// Get list of UserTypes
        /// </summary>
        /// <returns></returns>
        public List<tblUserTypeDto> GetUserTypes()
        {
            return masterDataProvider.GetUserTypes();
        }
    }
}
