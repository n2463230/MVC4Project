using AutoMapper;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore.ORM;

namespace FundingPilotSystem.UnifiedDataStore
{
    /// <summary>
    /// Peforms email log retated operations
    /// </summary>
    public class EmailLogProvider
    {
        /// <summary>
        /// Saves email log and remove email queue
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public int SaveEmailLog(tblEmailLogDto emailLogDto, int emailQueueId)
        {
            Mapper.CreateMap<tblEmailLogDto, tblEmailLog>();
            int result = 0;
            try
            {
                using (var fpCofigDataContext = new FPConfigEntities())
                {
                    // save email log 
                    var emailLog = new tblEmailLog();
                    Mapper.Map(emailLogDto, emailLog);
                    fpCofigDataContext.tblEmailLogs.Add(emailLog);

                    // remove email queue
                    var emailQueue = fpCofigDataContext.tblEmailQueues.Find(emailQueueId);
                    fpCofigDataContext.tblEmailQueues.Remove(emailQueue);

                    //save transaction
                    result = fpCofigDataContext.SaveChanges();
                }
            }
            catch
            {
                return -1;
            }
            return result;
        }
    }
}
