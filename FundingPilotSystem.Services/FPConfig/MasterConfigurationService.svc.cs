using FundingPilotSystem.BLL;
using FundingPilotSystem.Common;
using System.Collections.Generic;

namespace FundingPilotSystem.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MasterConfigurationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MasterConfigurationService.svc or MasterConfigurationService.svc.cs at the Solution Explorer and start debugging.
    public class MasterConfigurationService : IMasterConfigurationService
    {
        private MasterConfigurationBLL _masterConfigurationBLL;
        private FPApplication FPApplication { get; set; }
       
        public BO.MasterConfigurationBO GetMasterConfiguration()
        {
            return _masterConfigurationBLL.GetMasterConfiguration();
        }

        public void SetFPApplication(Common.FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this._masterConfigurationBLL = new MasterConfigurationBLL();
        }
    }
}