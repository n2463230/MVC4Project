using FundingPilotSystem.DAL;
using System.Collections.Generic;
using FundingPilotSystem.Common;
using LoggingFramework;
using FundingPilotSystem.BO;

namespace FundingPilotSystem.BLL
{

    /// <summary>
    /// This class contains business logic for master data
    /// </summary>
    public class MasterDataBLL
    {
        #region [Declaration]

        private FPApplication FPApplication { get; set; }
        private MasterDataProviderDAL masterDataDal;

        #endregion

        public MasterDataBLL(FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this.masterDataDal = new MasterDataProviderDAL(fpApplication);
        }
        /// <summary>
        /// Get list of countries
        /// </summary>
        /// <returns></returns>
        public List<CountryListBO> GetCountries()
        {
            Log4NetLogger.Info("BLL : In GetCountries");
            return masterDataDal.GetCountries();
        }
        /// <summary>
        /// Get list of account opening fields
        /// </summary>
        /// <returns></returns>
        public List<AccountOpeningFieldBO> GetAccountOpeningFields()
        {

            return masterDataDal.GetAccountOpeningFields();
        }
        /// <summary>
        /// Get list of company industries 
        /// </summary>
        /// <returns></returns>
        public List<CompanyIndustryListBO> GetCompanyIndustries()
        {
            return masterDataDal.GetCompanyIndustries();
        }
        /// <summary>
        /// Get list of Country Of Operations
        /// </summary>
        /// <returns></returns>
        public List<CountryOfOperationBO> GetCountryOfOperations()
        {
            return masterDataDal.GetCountryOfOperations();
        }
        /// <summary>
        /// Get list of KYCStatus
        /// </summary>
        /// <returns></returns>
        public List<KYCStatusBO> GetKYCStatus()
        {
            return masterDataDal.GetKYCStatus();
        }
        /// <summary>
        /// Get list of Public Authority Industry
        /// </summary>
        /// <returns></returns>
        public List<PublicAuthorityIndustryListBO> GetPublicAuthorityIndustries()
        {
            return masterDataDal.GetPublicAuthorityIndustries();
        }
        /// <summary>
        /// Get list of Supported AccountType
        /// </summary>
        /// <returns></returns>
        public List<SupportedAccountTypeBO> GetSupportedAccountType()
        {
            return masterDataDal.GetSupportedAccountType();
        }

        /// <summary>
        /// Get list of Supported Currencies
        /// </summary>
        /// <returns></returns>
        public List<SupportedCurrencyBO> GetSupportedCurrencies()
        {
            return masterDataDal.GetSupportedCurrencies();
        }
        /// <summary>
        /// Get list of Supported Languages
        /// </summary>
        /// <returns></returns>
        public List<SupportedLanguageBO> GetSupportedLanguages()
        {
            return masterDataDal.GetSupportedLanguages();
        }
        /// <summary>
        /// Get list of SystemModules
        /// </summary>
        /// <returns></returns>
        public List<SystemModuleBO> GetSystemModules()
        {
            return masterDataDal.GetSystemModules();
        }

        /// <summary>
        /// Get list of User Statuses
        /// </summary>
        /// <returns></returns>
        public List<UserStatusBO> GetUserStatuses()
        {
            return masterDataDal.GetUserStatuses();
        }
        /// <summary>
        /// Get list of UserTypes
        /// </summary>
        /// <returns></returns>
        public List<UserTypeBO> GetUserTypes()
        {
            return masterDataDal.GetUserTypes();
        }
    }
}
