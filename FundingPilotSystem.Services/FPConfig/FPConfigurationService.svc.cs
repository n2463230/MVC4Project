using System.Collections.Generic;
using System.ServiceModel;
using AutoMapper;
using FundingPilotSystem.BLL;
using FundingPilotSystem.BO;
using FundingPilotSystem.VM;
using LoggingFramework;
using FundingPilotSystem.Common;

namespace FundingPilotSystem.Services.FPConfig
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FPConfigurationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FPConfigurationService.svc or FPConfigurationService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FPConfigurationService : IFPConfigurationService
    {
        #region [Page Specific Configuration]

        /// <summary>
        /// Get list of static html pages
        /// </summary>
        /// <returns></returns>
        public List<PageSpecificPlaceholderConfigVM> GetAllPageSpecificPlaceholderConfig()
        {
            var pageSpecificPlaceholderConfigBLL = new PageSpecificPlaceholderConfigBLL();
            Mapper.CreateMap<PageSpecificPlaceholderConfigBO, PageSpecificPlaceholderConfigVM>();
            var pageSpecificPlaceholderConfigList = pageSpecificPlaceholderConfigBLL.GetAllPageSpecificPlaceholderConfig();
            return Mapper.Map(pageSpecificPlaceholderConfigList, new List<PageSpecificPlaceholderConfigVM>());
        }

        /// <summary>
        /// Delete page specfic place holder to set empty string to place holder
        /// </summary>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <returns></returns>
        public bool DeletePageSpecificPlaceholderConfig(int pageSpecificPlaceholderId, SolutionEnums.PageSpecificPlaceholder pageSpecificPlaceholder)
        {
            var pageSpecificPlaceholderConfigBLL = new PageSpecificPlaceholderConfigBLL();
            return pageSpecificPlaceholderConfigBLL.DeletePageSpecificPlaceholderConfig(pageSpecificPlaceholderId, pageSpecificPlaceholder);
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="tblPageSpecificPlaceholderConfigDto"></param>
        /// <returns></returns>
        public int SavePageSpecificPlaceholder(PageSpecificPlaceholderConfigVM PageSpecificPlaceholderConfigVM)
        {
            var pageSpecificPlaceholderConfigBLL = new PageSpecificPlaceholderConfigBLL();
            Mapper.CreateMap<PageSpecificPlaceholderConfigVM, PageSpecificPlaceholderConfigBO>();

            var pageSpecificPlaceholderConfigBO = new PageSpecificPlaceholderConfigBO();
            pageSpecificPlaceholderConfigBO = Mapper.Map<PageSpecificPlaceholderConfigVM, PageSpecificPlaceholderConfigBO>(PageSpecificPlaceholderConfigVM);

            return pageSpecificPlaceholderConfigBLL.SavePageSpecificPlaceholder(pageSpecificPlaceholderConfigBO);
        }

        #endregion

        #region [EmailNotificationService]

        #region [Email Queue]

        /// <summary>
        /// Update email queue
        /// </summary>
        /// <param name="emailQueueVM"></param>
        /// <returns></returns>
        public int UpdateEmailQueue(EmailQueueVM emailQueueVM)
        {
            var emailNotificationServiceBLL = new EmailNotificationServiceBLL();
            Mapper.CreateMap<EmailQueueVM, EmailQueueBO>();

            var emailQueueBO = new EmailQueueBO();
            emailQueueBO = Mapper.Map<EmailQueueVM, EmailQueueBO>(emailQueueVM);
            return emailNotificationServiceBLL.UpdateEmailQueue(emailQueueBO);
        }

        /// <summary>
        /// Get list of pending email queue
        /// </summary>
        /// <returns></returns>
        public List<EmailQueueVM> GetPendingEmailQueue()
        {
            var emailNotificationServiceBLL = new EmailNotificationServiceBLL();
            Mapper.CreateMap<EmailQueueBO, EmailQueueVM>();
            return Mapper.Map(emailNotificationServiceBLL.GetPendingEmailQueue(), new List<EmailQueueVM>());
        }

        #endregion

        #region [Email Log]

        /// <summary>
        /// Saves email log and remove email queue
        /// </summary>
        /// <param name="emailLogVM"></param>
        /// <returns>int</returns>
        public int SaveEmailLog(EmailLogVM emailLogVM, int emailQueueId)
        {
            var emailNotificationServiceBLL = new EmailNotificationServiceBLL();
            Mapper.CreateMap<EmailLogVM, EmailLogBO>();

            var emailLogBO = new EmailLogBO();
            emailLogBO = Mapper.Map<EmailLogVM, EmailLogBO>(emailLogVM);
            return emailNotificationServiceBLL.SaveEmailLog(emailLogBO, emailQueueId);
        }

        #endregion

        #endregion

        #region [Process Email Template]

        /// <summary>
        /// Save Process Email Template
        /// </summary>
        /// <param name="processEmailTemplateViewModel"></param>
        /// <returns></returns>
        public int SaveProcessEmailTemplate(ProcessEmailTemplateVM processEmailTemplateViewModel)
        {
            var emailTemplateConfigurationProviderBLL = new EmailTemplateConfigurationProviderBLL();
            Mapper.CreateMap<ProcessEmailTemplateVM, ProcessEmailTemplateBO>();

            var processEmailTemplateBO = new ProcessEmailTemplateBO();
            Mapper.Map(processEmailTemplateViewModel, processEmailTemplateBO);
            return emailTemplateConfigurationProviderBLL.SaveProcessEmailTemplate(processEmailTemplateBO);
        }

        /// <summary>
        /// Get All ProcessEmail Template
        /// </summary>
        /// <returns></returns>
        public List<ProcessEmailTemplateVM> GetAllProcessEmailTemplate()
        {
            Log4NetLogger.Info("Services : In GetAllProcessEmailTemplate");
            var emailTemplateConfigurationProviderBLL = new EmailTemplateConfigurationProviderBLL();
            Mapper.CreateMap<ProcessEmailTemplateBO, ProcessEmailTemplateVM>();
            Mapper.CreateMap<ProcessBO, ProcessVM>();

            return Mapper.Map(emailTemplateConfigurationProviderBLL.GetAllProcessEmailTemplate(), new List<ProcessEmailTemplateVM>());
        }

        /// <summary>
        /// Get ProcessEmail Template By Id
        /// </summary>
        /// <returns></returns>
        public ProcessEmailTemplateVM GetProcessEmailTemplate(int id)
        {
            Log4NetLogger.Info(string.Format("Services : In GetProcessEmailTemplate-{0}", id));
            var emailTemplateConfigurationProviderBLL = new EmailTemplateConfigurationProviderBLL();
            Mapper.CreateMap<ProcessEmailTemplateBO, ProcessEmailTemplateVM>();
            Mapper.CreateMap<ProcessBO, ProcessVM>();
            return Mapper.Map(emailTemplateConfigurationProviderBLL.GetProcessEmailTemplate(id), new ProcessEmailTemplateVM());
        }

        /// <summary>
        /// Get All Process
        /// </summary>
        /// <returns></returns>
        public List<ProcessVM> GetAllProcess()
        {
            Log4NetLogger.Info("Services : In GetAllProcess");
            var emailTemplateConfigurationProviderBLL = new EmailTemplateConfigurationProviderBLL();
            Mapper.CreateMap<ProcessBO, ProcessVM>();
            return Mapper.Map(emailTemplateConfigurationProviderBLL.GetAllProcess(), new List<ProcessVM>());
        }

        /// <summary>
        /// Delete  ProcessEmailTemplate
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public bool DeleteProcessEmailTemplate(int processEmailTemplateId)
        {
            Log4NetLogger.Info(string.Format("Services : In DeleteProcessEmailTemplate-{0}", processEmailTemplateId));
            var emailTemplateConfigurationProviderBLL = new EmailTemplateConfigurationProviderBLL();
            return emailTemplateConfigurationProviderBLL.DeleteProcessEmailTemplate(processEmailTemplateId);
        }

        #endregion

        #region [Master Configuration]

        /// <summary>
        /// Saves master configuration
        /// </summary>
        /// <param name="masterConfigurationViewModel"></param>
        /// <returns></returns>
        public int SaveMasterConfiguration(MasterConfigurationViewModel masterConfigurationViewModel)
        {
            var masterConfigurationBLL = new MasterConfigurationBLL();
            Mapper.CreateMap<MasterConfigurationViewModel, MasterConfigurationBO>();

            var masterConfigurationBO = new MasterConfigurationBO();
            masterConfigurationBO = Mapper.Map<MasterConfigurationViewModel, MasterConfigurationBO>(masterConfigurationViewModel);
            return masterConfigurationBLL.SaveMasterConfiguration(masterConfigurationBO);
        }

        /// <summary>
        /// Gets master configuration data
        /// </summary>
        /// <returns></returns>
        public MasterConfigurationViewModel GetMasterConfiguration()
        {
            Log4NetLogger.Info("Services : In GetMasterConfiguration");
            var masterConfigurationBLL = new MasterConfigurationBLL();
            Mapper.CreateMap<MasterConfigurationBO, MasterConfigurationViewModel>();
            return Mapper.Map(masterConfigurationBLL.GetMasterConfiguration(), new MasterConfigurationViewModel());
        }

        #endregion
    }
}