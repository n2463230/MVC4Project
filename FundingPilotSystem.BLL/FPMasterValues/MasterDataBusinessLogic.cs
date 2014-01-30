using FundingPilotSystem.DAL;
using System.Collections.Generic;
using FundingPilotSystem.Domain.FPMasterValues;
using FundingPilotSystem.Domain.SolutionDto;
using LoggingFramework;

namespace FundingPilotSystem.BLL
{
    public class MasterDataBusinessLogic
    {
        #region [Declaration]

        private FPApplication FPApplication { get; set; }
        private MasterDataProviderDAL masterDataDal;

        #endregion

        public MasterDataBusinessLogic(FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this.masterDataDal = new MasterDataProviderDAL(fpApplication);
        }
        /// <summary>
        /// Get list of countries
        /// </summary>
        /// <returns></returns>
        public List<tblCountryListDto> GetCountries()
        {
            Log4NetLogger.Info("BLL : In GetCountries");
            return masterDataDal.GetCountries();
        }
        /// <summary>
        /// Get list of account opening fields
        /// </summary>
        /// <returns></returns>
        public List<tblAccountOpeningFieldDto> GetAccountOpeningFields()
        {
           
            return masterDataDal.GetAccountOpeningFields();
        }
        /// <summary>
        /// Get list of company industries 
        /// </summary>
        /// <returns></returns>
        public List<tblCompanyIndustryListDto> GetCompanyIndustries()
        {
            return masterDataDal.GetCompanyIndustries();
        }
        /// <summary>
        /// Get list of Country Of Operations
        /// </summary>
        /// <returns></returns>
        public List<tblCountryOfOperationDto> GetCountryOfOperations()
        {
            return masterDataDal.GetCountryOfOperations();
        }
        /// <summary>
        /// Get list of KYCStatus
        /// </summary>
        /// <returns></returns>
        public List<tblKYCStatusDto> GetKYCStatus()
        {
            return masterDataDal.GetKYCStatus();
        }
        /// <summary>
        /// Get list of Public Authority Industry
        /// </summary>
        /// <returns></returns>
        public List<tblPublicAuthorityIndustryListDto> GetPublicAuthorityIndustries()
        {
            return masterDataDal.GetPublicAuthorityIndustries();
        }
        /// <summary>
        /// Get list of Supported AccountType
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedAccountTypeDto> GetSupportedAccountType()
        {
            return masterDataDal.GetSupportedAccountType();
        }

        /// <summary>
        /// Get list of Supported Currencies
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedCurrencyDto> GetSupportedCurrencies()
        {
            return masterDataDal.GetSupportedCurrencies();
        }
         /// <summary>
        /// Get list of Supported Languages
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedLanguageDto> GetSupportedLanguages()
        {
            return masterDataDal.GetSupportedLanguages();
        }
         /// <summary>
        /// Get list of SystemModules
        /// </summary>
        /// <returns></returns>
        public List<tblSystemModuleDto> GetSystemModules()
        {
            return masterDataDal.GetSystemModules();
        }
        
        /// <summary>
        /// Get list of User Statuses
        /// </summary>
        /// <returns></returns>
        public List<tblUserStatusDto> GetUserStatuses()
        {
            return masterDataDal.GetUserStatuses();
        }
        /// <summary>
        /// Get list of UserTypes
        /// </summary>
        /// <returns></returns>
        public List<tblUserTypeDto> GetUserTypes()
        {
            return masterDataDal.GetUserTypes();
        }
    }
}
