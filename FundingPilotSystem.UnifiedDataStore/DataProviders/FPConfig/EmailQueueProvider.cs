using AutoMapper;
using System.Linq;
using FundingPilotSystem.Domain;
using System.Collections.Generic;
using FundingPilotSystem.UnifiedDataStore.ORM;

namespace FundingPilotSystem.UnifiedDataStore
{
    /// <summary>
    /// Peforms email queue retated operations
    /// </summary>
    public class EmailQueueProvider
    {
        /// <summary>
        /// Updates email queue
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public int UpdateEmailQueue(tblEmailQueueDto emailQueueDto)
        {
            Mapper.CreateMap<tblEmailQueueDto, tblEmailQueue>();
            int result = 0;
            try
            {
                using (var fpCofigDataContext = new FPConfigEntities())
                {
                    var emailQueue = fpCofigDataContext.tblEmailQueues.Find(emailQueueDto.Id);
                    Mapper.Map(emailQueueDto, emailQueue);
                    result = fpCofigDataContext.SaveChanges();
                }
            }
            catch
            {
                return -1;
            }
            return result;
        }

        /// <summary>
        /// Get list of pending email queue
        /// </summary>
        /// <returns></returns>
        public List<tblEmailQueueDto> GetPendingEmailQueue()
        {
            using (var FPConfigEntitiesDataContext = new FPConfigEntities())
            {
                Mapper.CreateMap<tblEmailQueue, tblEmailQueueDto>();
                return Mapper.Map<List<tblEmailQueue>, List<tblEmailQueueDto>>(FPConfigEntitiesDataContext.tblEmailQueues.ToList());
            }
        }
    }
}
