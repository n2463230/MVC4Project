using AutoMapper;
using FundingPilotSystem.BLL;
using FundingPilotSystem.Domain.FPMasterValues;
using FundingPilotSystem.Domain.SolutionDto;
using FundingPilotSystem.Services.Utilities;
using LoggingFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace FundingPilotSystem.Services.FPMasterValues
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MasterDataProviderService : IMasterDataProviderService
    {

        private MasterDataBusinessLogic _masterDataBusinessLogic = null;
        private FPApplication FPApplication { get; set; }

        public void SetFPApplication(FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this._masterDataBusinessLogic = new MasterDataBusinessLogic(this.FPApplication);
        }
        public MasterDataProviderService()
        {
           
        }

        /// <summary>
        ///  call to get list of countries
        /// </summary>
        /// <returns></returns>
        public List<tblCountryListDto> GetCountries()
        {
            Log4NetLogger.Info("Services : In GetCountries");
            return _masterDataBusinessLogic.GetCountries();
        }
        /// <summary>
        ///  call to get list of account opening fields
        /// </summary>
        /// <returns></returns>
        public List<tblAccountOpeningFieldDto> GetAccountOpeningFields()
        {
            return _masterDataBusinessLogic.GetAccountOpeningFields();
        }
        /// <summary>
        ///  call to Get list of company industries 
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblCompanyIndustryListDto> GetCompanyIndustries()
        {
            return _masterDataBusinessLogic.GetCompanyIndustries();
        }
        /// <summary>
        ///   call to Get list of Country Of Operations
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblCountryOfOperationDto> GetCountryOfOperations()
        {
            return _masterDataBusinessLogic.GetCountryOfOperations();
        }
        /// <summary>
        ///  call to  Get list of KYCStatus
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblKYCStatusDto> GetKYCStatus()
        {
            return _masterDataBusinessLogic.GetKYCStatus();
        }

        /// <summary>
        ///  call to Get list of Public Authority Industry
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblPublicAuthorityIndustryListDto> GetPublicAuthorityIndustries()
        {
            return _masterDataBusinessLogic.GetPublicAuthorityIndustries();

        }
        /// <summary>
        ///  call to  Get list of Supported AccountType
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblSupportedAccountTypeDto> GetSupportedAccountType()
        {
            return _masterDataBusinessLogic.GetSupportedAccountType();

        }
        /// <summary>
        /// Get list of Supported Currencies
        /// </summary>
        /// <returns></returns>
        /// 

        public List<tblSupportedCurrencyDto> GetSupportedCurrencies()
        {
            return _masterDataBusinessLogic.GetSupportedCurrencies();
        }
        /// <summary>
        /// Get list of Supported Languages
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblSupportedLanguageDto> GetSupportedLanguages()
        {
            return _masterDataBusinessLogic.GetSupportedLanguages();

        }
        /// <summary>
        /// Get list of SystemModules
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblSystemModuleDto> GetSystemModules()
        {
            return _masterDataBusinessLogic.GetSystemModules();

        }
        /// <summary>
        /// Get list of User Statuses
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblUserStatusDto> GetUserStatuses()
        {
            return _masterDataBusinessLogic.GetUserStatuses();
        }
        /// <summary>
        /// Get list of UserTypes
        /// </summary>
        /// <returns></returns>
        /// 
        public List<tblUserTypeDto> GetUserTypes()
        {
            return _masterDataBusinessLogic.GetUserTypes();
        }
    }
}
