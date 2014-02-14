using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.DAL;
using FundingPilotSystem.VM;
using System;
using System.Collections.Generic;

namespace FundingPilotSystem.BLL
{

    /// <summary>
    /// This class contains business logic for user credentials
    /// </summary>
    public class UserCredentialBLL
    {

        /// <summary>
        /// Validates user login credentials
        /// </summary>
        /// <param name="userLoginCredentialBO"></param>
        /// <returns></returns>
        private bool ValidateUserLoginCredentials(UserLoginCredentialBO userLoginCredentialBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.UserId);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.LoginPassword);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.IsLocked);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.UserType);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.Key);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.Salt);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.CreatedBy);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginCredentialBO.CreatedOn);
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Saves user login credentials
        /// </summary>
        /// <param name="userLoginCredentialBO"></param>
        /// <returns></returns>
        public int SaveUserLoginCredentials(UserLoginCredentialBO userLoginCredentialBO)
        {
            int result = 0;
            if (ValidateUserLoginCredentials(userLoginCredentialBO))
            {
                

                UserCredentialProviderDAL objRegistrationProvider = new UserCredentialProviderDAL();
                result = objRegistrationProvider.SaveUserLoginCredentials(userLoginCredentialBO);
            }

            return result;
                      
        }


        /// <summary>
        /// Validates user login security questions
        /// </summary>
        /// <param name="userLoginQuetionBO"></param>
        /// <returns></returns>
        private bool ValidateUserLoginQuestions(UserLoginQuetionBO userLoginQuetionBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginQuetionBO.UserId);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginQuetionBO.SecretQuestion);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginQuetionBO.Answer);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginQuetionBO.CreatedBy);
                if (isValid) isValid = ValidateBLL.CheckNullOrEmpty(userLoginQuetionBO.CreatedOn);
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Saves user login security questions
        /// </summary>
        /// <param name="userLoginQuetionBO"></param>
        /// <returns></returns>
        public int SaveUserLoginQuestions(List<UserLoginQuetionBO> userLoginQuetionBO)
        {
            int result = 0;
            bool isValid = true;

            foreach (UserLoginQuetionBO objLoginQuestions in userLoginQuetionBO)
            {
                isValid = ValidateUserLoginQuestions(objLoginQuestions);
                if (!isValid) break;
            }
            if (isValid)
            {
                UserCredentialProviderDAL objRegistrationProvider = new UserCredentialProviderDAL();
                result = objRegistrationProvider.SaveUserLoginQuestions(userLoginQuetionBO);
            }
            return result;
        }
    }
}
