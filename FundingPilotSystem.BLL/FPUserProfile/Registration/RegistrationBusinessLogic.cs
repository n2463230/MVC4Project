using FundingPilotSystem.BLL.Common;
using FundingPilotSystem.VM.FPUserProfile;
using FundingPilotSystem.DAL.FPUserProfile.Registration;
using FundingPilotSystem.BO.FPUserProfile.Registration;
using System;
using AutoMapper;
using FundingPilotSystem.Domain.FPUserProfile;

namespace FundingPilotSystem.BLL.FPUserProfile.Registration
{
    public class RegistrationBusinessLogic
    {
        private bool ValidateUserRegistrationRequest(UserRegistrationRequestBusinessObject userRegistrationRequestBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userRegistrationRequestBO.UserEmail); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userRegistrationRequestBO.RegistrationDate);//checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userRegistrationRequestBO.UserStatus);//checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userRegistrationRequestBO.RegistrationIP);//checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(userRegistrationRequestBO.CountryOfRegistration);//checking for null or empty
            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return isValid = true;
        }

        private bool ValidateRegisteredUser(RegisteredUserBusinessObject registeredUserBO)
        {
            bool isValid = true;
            try
            {
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.UserEmail); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.CountryOfRegistration); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.NewsLetter); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.RegistrationDate); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.RegistrationIP); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.ConfirmationDate); //checking for null or empty

                /* Not Mandatory 
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.ConfirmationIP); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.ModifiedBy); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.ModifiedOn); //checking for null or empty
                if (isValid) isValid = ValidateBusinessLogic.CheckNullOrEmpty(registeredUserBO.IPAddressOfLastAction); //checking for null or empty
                */
            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return isValid = true;
        }

        public int SaveUserRegistrationRequest(UserRegistrationRequestBusinessObject userRegistrationRequestBO)
        {
            int result = 0;
            if (ValidateUserRegistrationRequest(userRegistrationRequestBO))
            {
                Mapper.CreateMap<UserRegistrationRequestBusinessObject, tblUserRegistrationRequestDto>();
                var userRegistrationRequestDto = new tblUserRegistrationRequestDto();
                Mapper.Map(userRegistrationRequestBO, userRegistrationRequestDto);

                RegistrationProviderDAL objRegistrationProvider = new RegistrationProviderDAL();
                result = objRegistrationProvider.SaveUserRegistrationRequest(userRegistrationRequestDto);
            }
            return result;
        }

        public int SaveRegisteredUser(RegisteredUserBusinessObject registeredUserBO)
        {
            int result = 0;
            if (ValidateRegisteredUser(registeredUserBO))
            {
                Mapper.CreateMap<RegisteredUserBusinessObject, tblRegisteredUserDto>();
                var registeredUserDto = new tblRegisteredUserDto();
                Mapper.Map(registeredUserBO, registeredUserDto);

                RegistrationProviderDAL objRegistrationProvider = new RegistrationProviderDAL();
                result = objRegistrationProvider.SaveRegisteredUser(registeredUserDto);
            }
            return result;
        }

        public bool isDuplicateUserEmailAddress(byte[] emailAddress)
        {
            RegistrationProviderDAL objRegistrationProvider = new RegistrationProviderDAL();
            return objRegistrationProvider.isDuplicateUserEmailAddress(emailAddress);
        }

    }
}
