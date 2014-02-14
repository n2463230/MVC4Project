using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.UnitTests
{
    [TestClass]
    public class MasterConfigurationProviderTest
    {
        [TestMethod]
        [TestCategory("Developer: UnifiedDataStore")]
        [Owner("Paresh Rao")]
        public void SaveMasterConfiguration()
        {
            //Unified Data Store
            tblMasterConfigurationDto objDto = new tblMasterConfigurationDto();

            objDto.MinPasswordLength = 8;
            objDto.RequireNumberInPassword = true;
            objDto.RequireSpecialCharacterInPassword = true;
            objDto.MaxPasswordLife = 100;
            objDto.MaxLogonRetry = 2;
            objDto.PasswordHistoryCount = 2;
            objDto.AllowReusePasswordFromHistory = false;
            objDto.CreatedBy = "Paresh Rao";
            objDto.CreatedOn = DateTime.Now;
            //Optional Fields
            objDto.ModifiedBy = "Ravi Keshwani";
            objDto.ModifiedOn = DateTime.Now;
            objDto.IPAddressOfLastAction = "10.7.200.300";
            objDto.DefaultEmailAddress = "pr@yasofttech.com";
            objDto.OutgoingEmailServer = "10.10.10.10";
            objDto.SenderMailAddress = "pareshgrao@gmail.com";
            objDto.EmailAccountUserName = "Pareshkumar Rao";
            objDto.EmailAccountUserPassword = "Pg@89083";


            MasterConfigurationProvider objMasterConfigurationProvider = new MasterConfigurationProvider();
            int returnVal = objMasterConfigurationProvider.SaveMasterConfiguration(objDto);

            Assert.AreEqual(1, returnVal, "It should return 1");
        }

        [TestMethod]
        [TestCategory("Developer: UnifiedDataStore")]
        [Owner("Paresh Rao")]
        public void GetMasterConfiguration()
        {
            MasterConfigurationProvider objMasterConfigurationProvider = new MasterConfigurationProvider();
            tblMasterConfigurationDto mastConfigDto = objMasterConfigurationProvider.GetMasterConfiguration();

            if (mastConfigDto !=null)
            {
                string returnString = mastConfigDto.EmailAccountUserName;
            }

            Assert.AreNotEqual(null, mastConfigDto, "It should not return null");
        }      
    }
}
