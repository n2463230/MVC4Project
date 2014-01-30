using AutoMapper;
using FundingPilotSystem.BLL.Common;
using FundingPilotSystem.BO.FPUserCredential;
using FundingPilotSystem.DAL;
using FundingPilotSystem.DAL.FPUserProfile.Registration;
using FundingPilotSystem.Domain.FPUserCredential;
using FundingPilotSystem.VM.FPUserProfile;
using System;
using System.Collections.Generic;


namespace FundingPilotSystem.BLL.FPUserCredential
{
    public class UserCredentialBusinessLogic
    {
        private bool ValidateUserLoginCredentials(UserLoginCredentialBusinessObject userLoginCredentialBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.UserId);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.LoginPassword);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.IsLocked);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.UserType);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.Key);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.Salt);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.CreatedBy);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginCredentialBO.CreatedOn);
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }

        public int SaveUserLoginCredentials(UserLoginCredentialBusinessObject userLoginCredentialBO)
        {
            int result = 0;
            if (ValidateUserLoginCredentials(userLoginCredentialBO))
            {
                Mapper.CreateMap<UserLoginCredentialBusinessObject, tblUserLoginCredentialsDto>();
                var userLoginCredentialsDto = new tblUserLoginCredentialsDto();
                Mapper.Map(userLoginCredentialBO, userLoginCredentialsDto);

                UserCredentialProviderDAL objRegistrationProvider = new UserCredentialProviderDAL();
                result = objRegistrationProvider.SaveUserLoginCredentials(userLoginCredentialsDto);
            }

            return result;
                      
        }

        private bool ValidateUserLoginQuestions(UserLoginQuetionBusinessObject userLoginQuetionBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginQuetionBO.UserId);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginQuetionBO.SecretQuestion);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginQuetionBO.Answer);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginQuetionBO.CreatedBy);
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userLoginQuetionBO.CreatedOn);
            }
            catch
            {
                isValid = false;
            }
            return isValid;
        }

        public int SaveUserLoginQuestions(IEnumerable<UserLoginQuetionBusinessObject> userLoginQuetionBO)
        {
            int result = 0;
            bool isValid = true;

            foreach (UserLoginQuetionBusinessObject objLoginQuestions in userLoginQuetionBO)
            {
                isValid = ValidateUserLoginQuestions(objLoginQuestions);
                if (!isValid) break;
            }
            if (isValid)
            {
                Mapper.CreateMap<UserLoginQuetionBusinessObject, tblUserLoginQuestionsDto>();
                var userLoginQuestionsDto = new List<tblUserLoginQuestionsDto>();
                Mapper.Map(userLoginQuetionBO, userLoginQuestionsDto);

                UserCredentialProviderDAL objRegistrationProvider = new UserCredentialProviderDAL();
                result = objRegistrationProvider.SaveUserLoginQuestions(userLoginQuestionsDto);
            }
            return result;
        }
    }
}
