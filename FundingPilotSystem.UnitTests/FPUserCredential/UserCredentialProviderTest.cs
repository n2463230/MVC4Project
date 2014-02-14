using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundingPilotSystem.Domain;
using System.Collections.Generic;
using FundingPilotSystem.UnifiedDataStore;
using FundingPilotSystem.Common;
namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class UserCredentialProviderTest
    {
        [TestMethod]
        [TestCategory("Developer: UnifiedDataStore")]
        [Owner("Paresh Rao")]
        public void SaveUserLoginCredentials()
        {
            tblUserLoginCredentialsDto objUserLoginCredentialDto = new tblUserLoginCredentialsDto();

            //Id
            objUserLoginCredentialDto.UserId = 101;
            objUserLoginCredentialDto.LoginPassword = Cryptography.Encrypt("Paresh@1234567");
            objUserLoginCredentialDto.LastPasswordChanged = DateTime.Now;
            objUserLoginCredentialDto.LastFailedLogin = DateTime.Now;
            objUserLoginCredentialDto.FailedLoginCount = 2;
            objUserLoginCredentialDto.IsLocked = false;
            objUserLoginCredentialDto.UserType = 1;
            objUserLoginCredentialDto.Key = Cryptography.Encrypt("Paresh@1234567");
            objUserLoginCredentialDto.Salt = Cryptography.Encrypt("Paresh@1234567");
            objUserLoginCredentialDto.CreatedBy = "Paresh Rao";
            objUserLoginCredentialDto.CreatedOn = DateTime.Now;
            objUserLoginCredentialDto.ModifiedBy = "Paresh Rao";
            objUserLoginCredentialDto.ModifiedOn = DateTime.Now;
            objUserLoginCredentialDto.IPAddressOfLastAction = "192.168.168.1";

            UserCredentialProvider objUserCredentialDataProvider = new UserCredentialProvider();
            int returnVal = objUserCredentialDataProvider.SaveUserLoginCredentials(objUserLoginCredentialDto);

            Assert.AreEqual(1, returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: UnifiedDataStore")]
        [Owner("Paresh Rao")]
        public void SaveUserLoginQuestions()
        {
            List<tblUserLoginQuestionsDto> userLoginQuestionsDto = new List<tblUserLoginQuestionsDto>();

            for (int i = 0; i < 5; i++)
            {
                tblUserLoginQuestionsDto objQuestions = new tblUserLoginQuestionsDto();
                objQuestions.UserId = 201;
                objQuestions.SecretQuestion = Cryptography.Encrypt("What is your Name " + i.ToString());
                objQuestions.Answer = Cryptography.Encrypt("My Name is " + i.ToString());
                objQuestions.CreatedBy = "CreatedBy Paresh " + i.ToString();
                objQuestions.CreatedOn = DateTime.Now;
                objQuestions.ModifiedBy = "ModifiedBy Paresh " + i.ToString();
                objQuestions.ModifiedOn = DateTime.Now;
                objQuestions.IPAddressOfLastAction = "192.168.15.24";
                userLoginQuestionsDto.Add(objQuestions);
            }

            UserCredentialProvider objUserCredentialDataProvider = new UserCredentialProvider();
            int returnVal = objUserCredentialDataProvider.SaveUserLoginQuestions(userLoginQuestionsDto);

            Assert.AreEqual(5,returnVal, "It should return 1");
        }
    }
}
