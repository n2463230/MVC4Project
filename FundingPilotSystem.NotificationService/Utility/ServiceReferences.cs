using System;
using FundingPilotSystem.Services.FPConfigurationService;

namespace FundingPilotSystem.NotificationService
{
    public static class ServiceReferences
    {
        /// <summary>
        /// Configurable MasterDataProviderService Url
        /// </summary>
        private static string FPConfigurationProviderServiceUrl
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FPConfigurationProviderServiceUrl"]);
            }
        }

        /// <summary>
        /// Get MasterProviderServiceClient
        /// </summary>
        private static FPConfigurationServiceClient _fpConfigurationServiceClient;

        public static FPConfigurationServiceClient FPConfigurationProviderServiceClient
        {
            get
            {
                if (_fpConfigurationServiceClient == null)
                {
                    System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress(FPConfigurationProviderServiceUrl);
                    System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode.None);
                    binding.MaxReceivedMessageSize = Int32.MaxValue;

                    binding.CloseTimeout = new TimeSpan(0, 30, 0);
                    binding.OpenTimeout = new TimeSpan(0, 30, 0);
                    binding.ReceiveTimeout = new TimeSpan(0, 30, 0);
                    binding.SendTimeout = new TimeSpan(0, 30, 0);

                    _fpConfigurationServiceClient = new FPConfigurationServiceClient(binding, address);
                }

                return _fpConfigurationServiceClient;
            }
        }
    }
}