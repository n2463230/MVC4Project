using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundingPilotSystem.Domain;
using FundingPilotSystem.DAL;
using System.Collections.Generic;
using FundingPilotSystem.BO;
using FundingPilotSystem.Common;
namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class UserCredentialProviderDALTest
    {
        [TestMethod]
        [TestCategory("Developer: DAL")]
        [Owner("Paresh Rao")]
        public void SaveUserLoginCredentials()
        {
            UserLoginCredentialBO objUserLoginCredentialBO = new UserLoginCredentialBO();

            //Id
            objUserLoginCredentialBO.UserId = 101;
            objUserLoginCredentialBO.LoginPassword = Cryptography.Encrypt("Paresh@1234567");
            objUserLoginCredentialBO.LastPasswordChanged = DateTime.Now;
            objUserLoginCredentialBO.LastFailedLogin = DateTime.Now;
            objUserLoginCredentialBO.FailedLoginCount = 2;
            objUserLoginCredentialBO.IsLocked = false;
            objUserLoginCredentialBO.UserType = 1;
            objUserLoginCredentialBO.Key = Cryptography.Encrypt("Paresh@1234567");
            objUserLoginCredentialBO.Salt = Cryptography.Encrypt("Paresh@1234567");
            objUserLoginCredentialBO.CreatedBy = "Paresh Rao";
            objUserLoginCredentialBO.CreatedOn = DateTime.Now;
            objUserLoginCredentialBO.ModifiedBy = "Paresh Rao";
            objUserLoginCredentialBO.ModifiedOn = DateTime.Now;
            objUserLoginCredentialBO.IPAddressOfLastAction = "192.168.168.1";

            UserCredentialProviderDAL objUserCredentialDataProvider = new UserCredentialProviderDAL();
            int returnVal = objUserCredentialDataProvider.SaveUserLoginCredentials(objUserLoginCredentialBO);

            Assert.AreEqual(1, returnVal, "It should return 1"); 
        }

        [TestMethod]
        [TestCategory("Developer: DAL")]
        [Owner("Paresh Rao")]
        public void SaveUserLoginQuestions()
        {
            List<UserLoginQuetionBO> userLoginQuestionsBO = new List<UserLoginQuetionBO>();

            for (int i = 0; i < 5; i++)
            {
                UserLoginQuetionBO objQuestionsBO = new UserLoginQuetionBO();
                objQuestionsBO.UserId = 201;
                objQuestionsBO.SecretQuestion = Cryptography.Encrypt("What is your Name " + i.ToString());
                objQuestionsBO.Answer = Cryptography.Encrypt("My Name is " + i.ToString());
                objQuestionsBO.CreatedBy = "CreatedBy Paresh " + i.ToString();
                objQuestionsBO.CreatedOn = DateTime.Now;
                objQuestionsBO.ModifiedBy = "ModifiedBy Paresh " + i.ToString();
                objQuestionsBO.ModifiedOn = DateTime.Now;
                objQuestionsBO.IPAddressOfLastAction = "192.168.15.24";
                userLoginQuestionsBO.Add(objQuestionsBO);
            }

            UserCredentialProviderDAL objUserCredentialDataProvider = new UserCredentialProviderDAL();
            int returnVal = objUserCredentialDataProvider.SaveUserLoginQuestions(userLoginQuestionsBO);

            Assert.AreEqual(5, returnVal, "It should return 1");
        }
    }
}
