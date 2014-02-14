using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;
using System.Collections.Generic;
using System.Linq;

namespace FundingPilotSystem.DAL
{
    public class EmailNotificationServiceProviderDAL
    {
        /// <summary>
        /// Update email queue
        /// </summary>
        /// <param name="masterConfigurationBO"></param>
        /// <returns></returns>
        public int UpdateEmailQueue(EmailQueueBO emailQueueBO)
        {
            Mapper.CreateMap<EmailQueueBO, tblEmailQueueDto>();
            tblEmailQueueDto tblEmailQueueDto = new Domain.tblEmailQueueDto();

            Mapper.Map(emailQueueBO, tblEmailQueueDto);
            EmailQueueProvider objEmailQueueProvider = new EmailQueueProvider();
            return objEmailQueueProvider.UpdateEmailQueue(tblEmailQueueDto);
        }

        /// <summary>
        /// Get list of pending email queue
        /// </summary>
        /// <returns></returns>
        public List<EmailQueueBO> GetPendingEmailQueue()
        {
            var emailTemeplateList = (new ProcessEmailTemplateProvider()).GetAllProcessEmailTemplate();
            var processList = (new ProcessesProvider()).GetAllProcess();
            var pendingEmailQueueList = (new EmailQueueProvider()).GetPendingEmailQueue();

            return (from emailQueue in pendingEmailQueueList
                    join process in processList

                        on emailQueue.Process equals process.Id
                    join emailTemplate in emailTemeplateList
                        on process.Id equals emailTemplate.ProcessId
                    select new EmailQueueBO
                    {
                        Id = emailQueue.Id,
                        Process = emailQueue.Process,
                        Receiver = emailQueue.Receiver,
                        UserId = emailQueue.UserId,
                        FirstName = emailQueue.FirstName,
                        MiddleName = emailQueue.MiddleName,
                        LastName = emailQueue.LastName,
                        HouseNo = emailQueue.HouseNo,
                        Side = emailQueue.Side,
                        Door = emailQueue.Door,
                        Streetname = emailQueue.Streetname,
                        AdditionalAddress_1 = emailQueue.AdditionalAddress_1,
                        AdditionalAddress_2 = emailQueue.AdditionalAddress_2,
                        ZipCode = emailQueue.ZipCode,
                        City = emailQueue.City,
                        Country = emailQueue.Country,
                        DOB = emailQueue.DOB,
                        Fixedphone = emailQueue.Fixedphone,
                        MobileNo = emailQueue.MobileNo,
                        KYCStatus = emailQueue.KYCStatus,
                        AccountNo = emailQueue.AccountNo,
                        AccountType = emailQueue.AccountType,
                        AdditionalInformation1 = emailQueue.AdditionalInformation1,
                        AdditionalInformation2 = emailQueue.AdditionalInformation2,
                        AdditionalInformation3 = emailQueue.AdditionalInformation3,
                        AdditionalInformation4 = emailQueue.AdditionalInformation4,
                        CreatedBy = emailQueue.CreatedBy,
                        CreatedOn = emailQueue.CreatedOn,
                        ErrorStatus = emailQueue.ErrorStatus,
                        EmailContent = emailTemplate.EmailContent,
                        ProcessName = process.ProcessName
                    }).ToList();
        }

        /// <summary>
        /// Saves email log and remove email queue
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public int SaveEmailLog(EmailLogBO emailLogBO, int emailQueueId)
        {
            Mapper.CreateMap<EmailLogBO, tblEmailLogDto>();
            var tblEmailLogDto = new Domain.tblEmailLogDto();

            Mapper.Map(emailLogBO, tblEmailLogDto);
            EmailLogProvider emailLogProvider = new EmailLogProvider();
            return emailLogProvider.SaveEmailLog(tblEmailLogDto, emailQueueId);
        }
    }
}
