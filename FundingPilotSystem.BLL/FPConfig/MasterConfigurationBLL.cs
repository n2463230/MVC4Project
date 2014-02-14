using FundingPilotSystem.BO;
using FundingPilotSystem.DAL;

namespace FundingPilotSystem.BLL
{
    /// <summary>
    /// This class contains business logic for master configuration
    /// </summary>
    public class MasterConfigurationBLL
    {
        /// <summary>
        /// Saves master configuration
        /// </summary>
        /// <param name="masterConfigurationBO"></param>
        /// <returns></returns>
        public int SaveMasterConfiguration(MasterConfigurationBO masterConfigurationBO)
        {
            int result = 0;
            if (ValidateMasterConfiguration(masterConfigurationBO))
            {                
                MasterConfigurationProviderDAL objMasterConfigurationProvider = new MasterConfigurationProviderDAL();
                result = objMasterConfigurationProvider.SaveMasterConfiguration(masterConfigurationBO);
            }
            return result;
        }

        /// <summary>
        /// Validates master configuration data
        /// </summary>
        /// <param name="masterConfigurationBO"></param>
        /// <returns></returns>
        private bool ValidateMasterConfiguration(MasterConfigurationBO masterConfigurationBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.MinPasswordLength);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.RequireNumberInPassword);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.RequireSpecialCharacterInPassword);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.MaxPasswordLife);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.MaxLogonRetry);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.PasswordHistoryCount);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.AllowReusePasswordFromHistory);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.CreatedBy);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(masterConfigurationBO.CreatedOn);
            }
            catch
            {
                isValid = false;
            }
            return isValid = true;
        }

        /// <summary>
        /// Gets master configuration data
        /// </summary>
        /// <returns></returns>
        public MasterConfigurationBO GetMasterConfiguration()
        {
            MasterConfigurationProviderDAL objMasterConfigurationProviderDAL = new MasterConfigurationProviderDAL();
            return objMasterConfigurationProviderDAL.GetMasterConfiguration();
        }
    }
}
