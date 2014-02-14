using AutoMapper;
using System.Linq;
using FundingPilotSystem.Domain;
using System.Collections.Generic;
using FundingPilotSystem.UnifiedDataStore.ORM;

namespace FundingPilotSystem.UnifiedDataStore
{
    /// <summary>
    /// Peforms process retated operations
    /// </summary>
    public class ProcessesProvider
    {
        /// <summary>
        /// Get list of process
        /// </summary>
        /// <returns></returns>
        public List<tblProcessDto> GetAllProcess()
        {
            using (var FPConfigEntitiesDataContext = new FPConfigEntities())
            {
                Mapper.CreateMap<tblProcess, tblProcessDto>();
                return Mapper.Map<List<tblProcess>, List<tblProcessDto>>(FPConfigEntitiesDataContext.tblProcesses.ToList());
            }
        }
    }
}
