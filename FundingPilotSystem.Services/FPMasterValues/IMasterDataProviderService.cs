
using FundingPilotSystem.BO;
using FundingPilotSystem.Common;
using FundingPilotSystem.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FundingPilotSystem.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMasterDataProviderService : ICommonService
    {
        [OperationContract]
        List<CountryListVM> GetCountries();

        [OperationContract]
        List<CountryOfOperationVM> GetCountryOfOperations();

        [OperationContract]
        List<SystemModuleVM> GetSystemModules();
    }


    
}
