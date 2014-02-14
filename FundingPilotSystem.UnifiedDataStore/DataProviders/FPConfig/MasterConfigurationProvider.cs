using AutoMapper;
using System.Linq;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore.ORM;

namespace FundingPilotSystem.UnifiedDataStore
{
    /// <summary>
    /// Peforms master configuration retated operations
    /// </summary>
    public class MasterConfigurationProvider
    {
        /// <summary>
        /// Saves/Updates master configuration
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public int SaveMasterConfiguration(tblMasterConfigurationDto masterConfigDto)
        {
            Mapper.CreateMap<tblMasterConfigurationDto, tblMasterConfig>();
            int result = 0;
            try
            {
                using (var masterConfigContext = new FPConfigEntities())
                {
                    var masterConfig = new tblMasterConfig();
                    //Update mode
                    if (masterConfigDto.Id > 0)
                    {
                        masterConfig = masterConfigContext.tblMasterConfigs.Find(masterConfigDto.Id);
                        Mapper.Map(masterConfigDto, masterConfig);
                        result = masterConfigContext.SaveChanges();
                    }
                    //New configuration 
                    else
                    {
                        Mapper.Map(masterConfigDto, masterConfig);
                        masterConfigContext.tblMasterConfigs.Add(masterConfig);
                        result = masterConfigContext.SaveChanges();
                    }
                }
            }
            catch
            {
                return -1;
            }
            return result;
        }

        /// <summary>
        /// Get list of master configuration
        /// </summary>
        /// <returns></returns>
        public tblMasterConfigurationDto GetMasterConfiguration()
        {
            tblMasterConfigurationDto objMastConfig = new tblMasterConfigurationDto();
            using (var dbMasterConfig = new FPConfigEntities())
            {
                Mapper.CreateMap<tblMasterConfig, tblMasterConfigurationDto>();

                var mstConfig = (from Config in dbMasterConfig.tblMasterConfigs
                                 select Config).FirstOrDefault();

                if (mstConfig != null)
                {
                    Mapper.Map(mstConfig, objMastConfig);
                }
            }
            return objMastConfig;
        }
    }
}
