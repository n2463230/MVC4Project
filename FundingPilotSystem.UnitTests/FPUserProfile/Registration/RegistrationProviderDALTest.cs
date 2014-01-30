using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundingPilotSystem.Domain.FPUserProfile;
using FundingPilotSystem.UnifiedDataStore.DataProviders;
using FundingPilotSystem.BLL.FPUserProfile.Registration;
using FundingPilotSystem.BO.FPUserProfile.Registration;
using FundingPilotSystem.Domain.SolutionUtilities;

namespace FundingPilotSystem.UnitTests.FPUserProfile.Registration
{
    [TestClass]
    public class RegistrationProviderDALTest
    {
        [TestMethod]
        public void SaveUserRegistrationRequest()
        {
            UserRegistrationRequestBusinessObject objUserRegistrationRequestBO = new UserRegistrationRequestBusinessObject();

            objUserRegistrationRequestBO.UserEmail = Cryptography.Encrypt("pareshgrao@gmail.com");
            objUserRegistrationRequestBO.CountryOfRegistration = 101;
            objUserRegistrationRequestBO.RegistrationDate = DateTime.Now;
            objUserRegistrationRequestBO.RegistrationIP = "192.168.1.101";
            objUserRegistrationRequestBO.UserStatus = 0;
            objUserRegistrationRequestBO.NewsLetter = true;
            objUserRegistrationRequestBO.LoginPassword = Cryptography.Encrypt("pareshgrao@gmail.com");

            RegistrationBusinessLogic objRegistrationBL = new RegistrationBusinessLogic();
            int result = objRegistrationBL.SaveUserRegistrationRequest(objUserRegistrationRequestBO);
            if (result == 1)
            {

            }
        }

        [TestMethod]
        public void SaveRegisteredUser()
        {
            RegisteredUserBusinessObject objRegisteredUserBO = new RegisteredUserBusinessObject();

            objRegisteredUserBO.UserEmail = Cryptography.Encrypt("pareshgrao@yahoo.co.in");
            objRegisteredUserBO.CountryOfRegistration = 101;
            objRegisteredUserBO.NewsLetter = true;
            objRegisteredUserBO.RegistrationDate = DateTime.Now;
            objRegisteredUserBO.RegistrationIP = "192.168.1.101";
            objRegisteredUserBO.ConfirmationDate = DateTime.Now;
            objRegisteredUserBO.ConfirmationIP = "192.168.1.10";

            RegistrationBusinessLogic objRegistrationBL = new RegistrationBusinessLogic();
            int result = objRegistrationBL.SaveRegisteredUser(objRegisteredUserBO);
            if (result == 1)
            {

            }
        }
    }
}
