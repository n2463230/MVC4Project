using FundingPilotSystem.Services.Utilities;
using FundingPilotSystem.VM.FPUserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FundingPilotSystem.Services.FPUserProfile
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRegistration" in both code and config file together.
    [ServiceContract]
    public interface IRegistrationServices : ICommonService
    {
        [OperationContract]
        int SaveUserRegistrationRequest(UserRegistrationRequestsViewModel model);
    }
}
