using FundingPilotSystem.BO;
using FundingPilotSystem.DAL;
using FundingPilotSystem.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class MasterConfigurationProviderDALTest
    {

        [TestMethod]
        [TestCategory("Developer: DAL")]
        [Owner("Paresh Rao")]
        public void SaveMasterConfiguration()
        {
            MasterConfigurationBO objMasterConfigurationBO = new MasterConfigurationBO();

            objMasterConfigurationBO.MinPasswordLength = 8;
            objMasterConfigurationBO.RequireNumberInPassword = true;
            objMasterConfigurationBO.RequireSpecialCharacterInPassword = true;
            objMasterConfigurationBO.MaxPasswordLife = 100;
            objMasterConfigurationBO.MaxLogonRetry = 2;
            objMasterConfigurationBO.PasswordHistoryCount = 2;
            objMasterConfigurationBO.AllowReusePasswordFromHistory = false;
            objMasterConfigurationBO.CreatedBy = "Paresh Rao";
            objMasterConfigurationBO.CreatedOn = DateTime.Now;
            //Optional Fields
            objMasterConfigurationBO.ModifiedBy = "Ravi Keshwani";
            objMasterConfigurationBO.ModifiedOn = DateTime.Now;
            objMasterConfigurationBO.IPAddressOfLastAction = "10.7.200.300";
            objMasterConfigurationBO.DefaultEmailAddress = "pr@yasofttech.com";
            objMasterConfigurationBO.OutgoingEmailServer = "10.10.10.10";
            objMasterConfigurationBO.SenderMailAddress = "pareshgrao@gmail.com";
            objMasterConfigurationBO.EmailAccountUserName = "Pareshkumar Rao";
            objMasterConfigurationBO.EmailAccountUserPassword = "Pg@89083";


            MasterConfigurationProviderDAL objMasterConfigurationProviderDAL = new MasterConfigurationProviderDAL();
            int returnVal = objMasterConfigurationProviderDAL.SaveMasterConfiguration(objMasterConfigurationBO);

            Assert.AreEqual(1,returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: DAL")]
        [Owner("Paresh Rao")]
        public void GetMasterConfiguration()
        {
            MasterConfigurationProviderDAL objMasterConfigurationProviderDAL = new MasterConfigurationProviderDAL();
            MasterConfigurationBO mastConfigBO = objMasterConfigurationProviderDAL.GetMasterConfiguration();

            if (mastConfigBO != null)
            {
                string returnString = mastConfigBO.EmailAccountUserName;
            }

            Assert.AreNotEqual(null, mastConfigBO, "It should not return null");
        }     
    }
}
