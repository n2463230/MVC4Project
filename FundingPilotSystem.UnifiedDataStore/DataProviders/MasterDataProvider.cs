using AutoMapper;
using FundingPilotSystem.Domain.FPMasterValues;
using FundingPilotSystem.Domain.SolutionDto;
using FundingPilotSystem.UnifiedDataStore.ORM;
using LoggingFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FundingPilotSystem.UnifiedDataStore.DataProviders
{
    public class MasterDataProvider
    {
        #region [Declaration]

        private FPApplication FPApplication { get; set; }

        #endregion

        public MasterDataProvider(FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
        }
        /// <summary>
        /// Get list of countries
        /// </summary>
        /// <returns></returns>
        public List<tblCountryListDto> GetCountries()
        {
            Log4NetLogger.Info("UnifiedDataStore : In GetCountries");
            
            Mapper.CreateMap<tblCountryList, tblCountryListDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblCountryLists.ToList(), new List<tblCountryListDto>());
            }
        }

        /// <summary>
        /// Get list of account opening fields
        /// </summary>
        /// <returns></returns>
        public List<tblAccountOpeningFieldDto> GetAccountOpeningFields()
        {
            Mapper.CreateMap<tblAccountOpeningField, tblAccountOpeningFieldDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblAccountOpeningFields.ToList(), new List<tblAccountOpeningFieldDto>());
            }
        }

        /// <summary>
        /// Get list of company insdustries 
        /// </summary>
        /// <returns></returns>
        public List<tblCompanyIndustryListDto> GetCompanyIndustries()
        {
            Mapper.CreateMap<tblCompanyIndustryList, tblCompanyIndustryListDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblCompanyIndustryLists.ToList(), new List<tblCompanyIndustryListDto>());
            }
        }

        /// <summary>
        /// Get list of Country Of Operations
        /// </summary>
        /// <returns></returns>
        public List<tblCountryOfOperationDto> GetCountryOfOperations()
        {
            Mapper.CreateMap<tblCountryOfOperation, tblCountryOfOperationDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblCountryOfOperations.ToList(), new List<tblCountryOfOperationDto>());
            }
        }

        /// <summary>
        /// Get list of KYCStatus
        /// </summary>
        /// <returns></returns>
        public List<tblKYCStatusDto> GetKYCStatus()
        {
            Mapper.CreateMap<tblKYCStatus, tblKYCStatusDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblKYCStatuses.ToList(), new List<tblKYCStatusDto>());
            }
        }

        /// <summary>
        /// Get list of Public Authority Industry
        /// </summary>
        /// <returns></returns>
        public List<tblPublicAuthorityIndustryListDto> GetPublicAuthorityIndustries()
        {
            Mapper.CreateMap<tblPublicAuthorityIndustryList, tblPublicAuthorityIndustryListDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblPublicAuthorityIndustryLists.ToList(),
                                                        new List<tblPublicAuthorityIndustryListDto>());
            }
        }

        /// <summary>
        /// Get list of Supported AccountType
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedAccountTypeDto> GetSupportedAccountType()
        {
            Mapper.CreateMap<tblSupportedAccountType, tblSupportedAccountTypeDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblSupportedAccountTypes.ToList(),
                                                        new List<tblSupportedAccountTypeDto>());
            }
        }

        /// <summary>
        /// Get list of Supported Currencies
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedCurrencyDto> GetSupportedCurrencies()
        {
            Mapper.CreateMap<tblSupportedCurrency, tblSupportedCurrencyDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblSupportedCurrencies.ToList(),
                                                        new List<tblSupportedCurrencyDto>());
            }
        }

        /// <summary>
        /// Get list of Supported Languages
        /// </summary>
        /// <returns></returns>
        public List<tblSupportedLanguageDto> GetSupportedLanguages()
        {
            Mapper.CreateMap<tblSupportedLanguage, tblSupportedLanguageDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblSupportedLanguages.ToList(),
                                                        new List<tblSupportedLanguageDto>());
            }
        }

        /// <summary>
        /// Get list of SystemModules
        /// </summary>
        /// <returns></returns>
        public List<tblSystemModuleDto> GetSystemModules()
        {
            Mapper.CreateMap<tblSystemModule, tblSystemModuleDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblSystemModules.ToList(),
                                                        new List<tblSystemModuleDto>());
            }
        }

        /// <summary>
        /// Get list of User Statuses
        /// </summary>
        /// <returns></returns>
        public List<tblUserStatusDto> GetUserStatuses()
        {
            Mapper.CreateMap<tblUserStatus, tblUserStatusDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblUserStatuses.ToList(),
                                                        new List<tblUserStatusDto>());
            }
        }

        /// <summary>
        /// Get list of UserTypes
        /// </summary>
        /// <returns></returns>
        public List<tblUserTypeDto> GetUserTypes()
        {
            Mapper.CreateMap<tblUserType, tblUserTypeDto>();

            using (var masterDataContext = new FPMasterValuesEntities())
            {
                return Mapper.Map(masterDataContext.tblUserTypes.ToList(),
                                                        new List<tblUserTypeDto>());
            }
        }
    }
}
