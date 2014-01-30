using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundingPilotSystem.Domain.FPUserProfile;
using FundingPilotSystem.Domain.SolutionUtilities;
using FundingPilotSystem.UnifiedDataStore.DataProviders;


namespace FundingPilotSystem.UnitTests.FPUserProfile.Registration
{
    [TestClass]
    public class RegistrationProviderTest
    {
        [TestMethod]
        public void SaveUserRegistrationRequest()
        {
            //Unified Data Store
            tblUserRegistrationRequestDto objDto = new tblUserRegistrationRequestDto();

            objDto.UserEmail = Cryptography.Encrypt("pareshgrao@gmail.com");
            objDto.CountryOfRegistration = 101;
            objDto.RegistrationDate = DateTime.Now;
            objDto.RegistrationIP = "192.168.1.101";
            objDto.UserStatus = 0;
            objDto.NewsLetter = true;
            objDto.LoginPassword = Cryptography.Encrypt("pareshgrao@gmail.com");

            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            int returnVal = objUserProfileDataProvider.SaveUserRegistrationRequest(objDto);
        }

        [TestMethod]
        public void SaveRegisteredUser()
        {
            tblRegisteredUserDto objDto = new tblRegisteredUserDto();

            objDto.UserEmail = Cryptography.Encrypt("pareshgrao@yahoo.co.in");
            objDto.CountryOfRegistration = 101;
            objDto.NewsLetter = true;
            objDto.RegistrationDate = DateTime.Now;
            objDto.RegistrationIP = "192.168.1.101";
            objDto.ConfirmationDate = DateTime.Now;
            objDto.ConfirmationIP = "192.168.1.10";

            RegistrationProvider objRegistrationProvider = new RegistrationProvider();
            int returnVal = objRegistrationProvider.SaveRegisteredUser(objDto);
        }
    }
}
