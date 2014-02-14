using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundingPilotSystem.BO;
using FundingPilotSystem.BLL;
using FundingPilotSystem.Domain;
using FundingPilotSystem.Common;
namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class RegistrationBLLTest
    {
        [TestMethod]
        [TestCategory("Developer: BLL")]
        [Owner("Paresh Rao")]
        public void SaveUserRegistrationRequest()
        {
            UserRegistrationRequestBO objUserRegistrationRequestBO = new UserRegistrationRequestBO();

            objUserRegistrationRequestBO.UserEmail = Cryptography.Encrypt("pareshgrao@gmail.com");
            objUserRegistrationRequestBO.CountryOfRegistration = 101;
            objUserRegistrationRequestBO.RegistrationDate = DateTime.Now;
            objUserRegistrationRequestBO.RegistrationIP = "192.168.1.101";
            objUserRegistrationRequestBO.UserStatus = 0;
            objUserRegistrationRequestBO.NewsLetter = true;
            objUserRegistrationRequestBO.LoginPassword = Cryptography.Encrypt("pareshgrao@gmail.com");

            RegistrationBLL objRegistrationBL = new RegistrationBLL();
            int returnVal = objRegistrationBL.SaveUserRegistrationRequest(objUserRegistrationRequestBO);

            Assert.AreEqual(1, returnVal, "It should return 1"); 
        }

        [TestMethod]
        [TestCategory("Developer: BLL")]
        [Owner("Paresh Rao")]
        public void SaveRegisteredUser()
        {
            RegisteredUserBO objRegisteredUserBO = new RegisteredUserBO();

            objRegisteredUserBO.UserEmail = Cryptography.Encrypt("pareshgrao@yahoo.co.in");
            objRegisteredUserBO.CountryOfRegistration = 101;
            objRegisteredUserBO.NewsLetter = true;
            objRegisteredUserBO.RegistrationDate = DateTime.Now;
            objRegisteredUserBO.RegistrationIP = "192.168.1.101";
            objRegisteredUserBO.ConfirmationDate = DateTime.Now;
            objRegisteredUserBO.ConfirmationIP = "192.168.1.10";

            RegistrationBLL objRegistrationBL = new RegistrationBLL();
            int returnVal = objRegistrationBL.SaveRegisteredUser(objRegisteredUserBO);

            Assert.AreEqual(1, returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: BLL")]
        [Owner("Paresh Rao")]
        public void isDuplicateUserEmailAddress()
        {
            RegistrationBLL objRegistrationBL = new RegistrationBLL();
            bool returnVal = objRegistrationBL.isDuplicateUserEmailAddress(Cryptography.Encrypt("rk@yasofttech.com"));

            Assert.AreNotEqual(-1, returnVal, "It should not return  -1");
        }
       
    }
}
