using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundingPilotSystem.BLL;
using FundingPilotSystem.BO;
using System.Collections.Generic;
using FundingPilotSystem.Domain;
using FundingPilotSystem.Common;

namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class UserCredentialBLLTest
    {
        [TestMethod]
        [TestCategory("Developer: BLL")]
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

            UserCredentialBLL objUserCredentialBusinessLogic = new UserCredentialBLL();
            int returnVal = objUserCredentialBusinessLogic.SaveUserLoginCredentials(objUserLoginCredentialBO);

            Assert.AreEqual(1, returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: BLL")]
        [Owner("Paresh Rao")]
        public void SaveUserLoginQuestions()
        {
            List<UserLoginQuetionBO> userLoginQuestionsBO = new List<UserLoginQuetionBO>();

            for (int i = 0; i < 5; i++)
            {
                UserLoginQuetionBO objQuestions = new UserLoginQuetionBO();
                objQuestions.UserId = 201;
                objQuestions.SecretQuestion = Cryptography.Encrypt("What is your Name " + i.ToString());
                objQuestions.Answer = Cryptography.Encrypt("My Name is " + i.ToString());
                objQuestions.CreatedBy = "CreatedBy Paresh " + i.ToString();
                objQuestions.CreatedOn = DateTime.Now;
                objQuestions.ModifiedBy = "ModifiedBy Paresh " + i.ToString();
                objQuestions.ModifiedOn = DateTime.Now;
                objQuestions.IPAddressOfLastAction = "192.168.15.24";
                userLoginQuestionsBO.Add(objQuestions);
            }

            UserCredentialBLL objUserCredentialBusinessLogic = new UserCredentialBLL();
            int returnVal = objUserCredentialBusinessLogic.SaveUserLoginQuestions(userLoginQuestionsBO);

            Assert.AreEqual(5, returnVal, "It should return 1");
        }
    }
}
