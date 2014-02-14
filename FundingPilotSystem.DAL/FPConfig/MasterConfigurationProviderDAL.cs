using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;

namespace FundingPilotSystem.DAL
{
    /// <summary>
    /// This class provides master configuration related functionalities
    /// </summary>
    public class MasterConfigurationProviderDAL
    {
        /// <summary>
        /// Saves master configurations
        /// </summary>
        /// <param name="masterConfigurationBO"></param>
        /// <returns></returns>
        public int SaveMasterConfiguration(MasterConfigurationBO masterConfigurationBO)
        {
            Mapper.CreateMap<MasterConfigurationBO, tblMasterConfigurationDto>();
            tblMasterConfigurationDto tblMasterConfigurationDto = new Domain.tblMasterConfigurationDto();

            Mapper.Map(masterConfigurationBO, tblMasterConfigurationDto);
            MasterConfigurationProvider objMasterConfigurationProvider = new MasterConfigurationProvider();
            return objMasterConfigurationProvider.SaveMasterConfiguration(tblMasterConfigurationDto);
        }

        /// <summary>
        /// Gets master configurations
        /// </summary>
        /// <returns></returns>
        public MasterConfigurationBO GetMasterConfiguration()
        {
            Mapper.CreateMap<tblMasterConfigurationDto, MasterConfigurationBO>();
            MasterConfigurationProvider objMasterConfigurationProvider = new MasterConfigurationProvider();
            return Mapper.Map(objMasterConfigurationProvider.GetMasterConfiguration(), new MasterConfigurationBO());
        }
    }
}
