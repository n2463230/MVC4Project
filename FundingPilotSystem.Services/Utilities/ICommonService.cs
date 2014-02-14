using FundingPilotSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Services
{
    [ServiceContract]
    public interface ICommonService
    {
        [OperationContract]
        void SetFPApplication(FPApplication fpApplication);
    }
}
