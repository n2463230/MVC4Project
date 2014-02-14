using FundingPilotSystem.BLL;
using FundingPilotSystem.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class MasterConfigurationBLLTest
    {
        [TestMethod]
        [TestCategory("Developer: BLL")]
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

            MasterConfigurationBLL objMasterConfigBL = new MasterConfigurationBLL();
            int returnVal = objMasterConfigBL.SaveMasterConfiguration(objMasterConfigurationBO);

            Assert.AreEqual(1,returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: BLL")]
        [Owner("Paresh Rao")]
        public void GetMasterConfiguration()
        {
            MasterConfigurationBLL objMasterConfigBL = new MasterConfigurationBLL();
            MasterConfigurationBO mastConfigBO = objMasterConfigBL.GetMasterConfiguration();

            if (mastConfigBO != null)
            {
                string returnString = mastConfigBO.EmailAccountUserName;
            }

            Assert.AreNotEqual(null, mastConfigBO, "It should not return null");
        }
    }
}
