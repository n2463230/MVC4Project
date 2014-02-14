using FundingPilotSystem.BO;
using FundingPilotSystem.DAL;

namespace FundingPilotSystem.BLL
{
    /// <summary>
    /// This class contains business logic for user registration process
    /// </summary>
    public class RegistrationBLL
    {

        /// <summary>
        /// Validates registration request data
        /// </summary>
        /// <param name="userRegistrationRequestBO"></param>
        /// <returns></returns>
        private bool ValidateUserRegistrationRequest(UserRegistrationRequestBO userRegistrationRequestBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userRegistrationRequestBO.UserEmail); //checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userRegistrationRequestBO.RegistrationDate);//checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userRegistrationRequestBO.UserStatus);//checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userRegistrationRequestBO.RegistrationIP);//checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userRegistrationRequestBO.CountryOfRegistration);//checking for null or empty
            }
            catch
            {
                isValid = false;
            }
            return isValid = true;
        }


        /// <summary>
        /// Validates registered user data
        /// </summary>
        /// <param name="registeredUserBO"></param>
        /// <returns></returns>
        private bool ValidateRegisteredUser(RegisteredUserBO registeredUserBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(registeredUserBO.UserEmail); //checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(registeredUserBO.CountryOfRegistration); //checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(registeredUserBO.NewsLetter); //checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(registeredUserBO.RegistrationDate); //checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(registeredUserBO.RegistrationIP); //checking for null or empty
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(registeredUserBO.ConfirmationDate); //checking for null or empty
            }
            catch
            {
                isValid = false;
            }
            return isValid = true;
        }

        /// <summary>
        /// Saves user registration requests
        /// </summary>
        /// <param name="userRegistrationRequestBO"></param>
        /// <returns></returns>
        public int SaveUserRegistrationRequest(UserRegistrationRequestBO userRegistrationRequestBO)
        {
            int result = 0;
            if (ValidateUserRegistrationRequest(userRegistrationRequestBO))
            {               
                RegistrationProviderDAL objRegistrationProvider = new RegistrationProviderDAL();
                result = objRegistrationProvider.SaveUserRegistrationRequest(userRegistrationRequestBO);
            }
            return result;
        }

        /// <summary>
        /// Saves registered users (after user peforms email varification)
        /// </summary>
        /// <param name="registeredUserBO"></param>
        /// <returns></returns>
        public int SaveRegisteredUser(RegisteredUserBO registeredUserBO)
        {
            int result = 0;
            if (ValidateRegisteredUser(registeredUserBO))
            {
                

                RegistrationProviderDAL objRegistrationProvider = new RegistrationProviderDAL();
                result = objRegistrationProvider.SaveRegisteredUser(registeredUserBO);
            }
            return result;
        }

        /// <summary>
        /// Checks for duplicate user email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool isDuplicateUserEmailAddress(byte[] emailAddress)
        {
            RegistrationProviderDAL objRegistrationProvider = new RegistrationProviderDAL();
            return objRegistrationProvider.isDuplicateUserEmailAddress(emailAddress);
        }

    }
}
