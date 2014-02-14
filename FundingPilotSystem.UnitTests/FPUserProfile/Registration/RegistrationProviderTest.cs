using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;
using FundingPilotSystem.Common;
namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class RegistrationProviderTest
    {
        [TestMethod]
        [TestCategory("Developer: UnifiedDataStore")]
        [Owner("Paresh Rao")]
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

            Assert.AreEqual(1, returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: UnifiedDataStore")]
        [Owner("Paresh Rao")]
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

            Assert.AreEqual(1, returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: UnifiedDataStore")]
        [Owner("Paresh Rao")]
        public void isDuplicateUserEmailAddress()
        {
            RegistrationProvider objRegistrationProvider = new RegistrationProvider();
            bool returnVal = objRegistrationProvider.isDuplicateUserEmailAddress(Cryptography.Encrypt("rk@yasofttech.com"));

            Assert.AreNotEqual(-1,returnVal, "It should not return -1");
        }
    }
}
