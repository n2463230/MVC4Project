using FundingPilotSystem.Domain.SolutionDto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using MasterDataProviderService= FundingPilotSystem.Services.FPMasterValues.MasterDataProviderService;
using RegistrationService = FundingPilotSystem.Services.FPUserProfile.RegistrationService;
namespace FundingPilotSystem.Utilities
{
    public static class ServiceReferences
    {

        /// <summary>
        /// Common Object use to access current context data
        /// </summary>
        public static FPApplication FPApplication
        {
            get
            {
                return CurrentFPApplicationContext.GetFPApplication();
            }
        }
        /// <summary>
        /// Configurable MasterDataProviderService Url
        /// </summary>
        private static string MasterDataProviderServiceUrl
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["MasterDataProviderServiceUrl"]);
            }
        }

        /// <summary>
        /// Get MasterProviderServiceClient
        /// </summary>
        private static MasterDataProviderService.MasterDataProviderServiceClient _masterProviderServiceClient;
       
        internal static MasterDataProviderService.IMasterDataProviderService GetMasterProviderServiceClient()
        {
           
                if (_masterProviderServiceClient == null)
                {
                    System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress(MasterDataProviderServiceUrl);
                    System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode.None);
                    binding.MaxReceivedMessageSize = Int32.MaxValue;

                    binding.CloseTimeout = new TimeSpan(0, 30, 0);
                    binding.OpenTimeout = new TimeSpan(0, 30, 0);
                    binding.ReceiveTimeout = new TimeSpan(0, 30, 0);
                    binding.SendTimeout = new TimeSpan(0, 30, 0);

                    _masterProviderServiceClient = new MasterDataProviderService.MasterDataProviderServiceClient(binding, address);
                }
                _masterProviderServiceClient.SetFPApplication(ServiceReferences.FPApplication);
                return _masterProviderServiceClient;
            
        }

        /// <summary>
        /// Configurable Registration Process Url
        /// </summary>
        private static string RegistrationProcessServiceUrl
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["RegistrationProcessServiceUrl"]);
            }
        }

        /// <summary>
        /// Get RegistrationProcessClient
        /// </summary>
        private static RegistrationService.RegistrationServicesClient _registrationServiceClient;

        internal static RegistrationService.IRegistrationServices GetRegistrationProcessClient()
        {

            if (_registrationServiceClient == null)
            {
                System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress(RegistrationProcessServiceUrl);
                System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode.None);
                binding.MaxReceivedMessageSize = Int32.MaxValue;

                binding.CloseTimeout = new TimeSpan(0, 30, 0);
                binding.OpenTimeout = new TimeSpan(0, 30, 0);
                binding.ReceiveTimeout = new TimeSpan(0, 30, 0);
                binding.SendTimeout = new TimeSpan(0, 30, 0);

                _registrationServiceClient = new RegistrationService.RegistrationServicesClient(binding, address);
            }
            _registrationServiceClient.SetFPApplication(ServiceReferences.FPApplication);
            return _registrationServiceClient;

        }
    }
}