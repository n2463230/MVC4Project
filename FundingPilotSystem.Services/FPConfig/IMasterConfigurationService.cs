using FundingPilotSystem.BO;
using System.ServiceModel;

namespace FundingPilotSystem.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMasterConfigurationService" in both code and config file together.
    [ServiceContract]
    public interface IMasterConfigurationService:ICommonService
    {
        [OperationContract]
        MasterConfigurationBO GetMasterConfiguration();
    }
}