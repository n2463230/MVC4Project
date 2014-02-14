using FundingPilotSystem.BO;
using FundingPilotSystem.DAL;
using System.Collections.Generic;

namespace FundingPilotSystem.BLL
{
    public class EmailNotificationServiceBLL
    {
        /// <summary>
        /// Saves email log and remove email queue
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public int SaveEmailLog(EmailLogBO emailLogBO, int emailQueueId)
        {
            var emailNotificationServiceProviderDAL = new EmailNotificationServiceProviderDAL();
            return emailNotificationServiceProviderDAL.SaveEmailLog(emailLogBO, emailQueueId);
        }

        /// <summary>
        /// Update email queue
        /// </summary>
        /// <param name="masterConfigurationBO"></param>
        /// <returns></returns>
        public int UpdateEmailQueue(EmailQueueBO emailQueueBO)
        {
            var emailNotificationServiceProviderDAL = new EmailNotificationServiceProviderDAL();
            return emailNotificationServiceProviderDAL.UpdateEmailQueue(emailQueueBO);
        }

        /// <summary>
        /// Get list of pending email queue
        /// </summary>
        /// <returns></returns>
        public List<EmailQueueBO> GetPendingEmailQueue()
        {
            var emailNotificationServiceProviderDAL = new EmailNotificationServiceProviderDAL();
            return emailNotificationServiceProviderDAL.GetPendingEmailQueue();
        }
    }
}
