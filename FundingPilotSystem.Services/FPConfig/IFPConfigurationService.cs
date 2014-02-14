using System.Collections.Generic;
using System.ServiceModel;
using FundingPilotSystem.VM;
using FundingPilotSystem.Common;

namespace FundingPilotSystem.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFPConfigurationService" in both code and config file together.
    [ServiceContract]
    public interface IFPConfigurationService
    {
        #region [Page Specific Configuration]

        [OperationContract]
        List<PageSpecificPlaceholderConfigVM> GetAllPageSpecificPlaceholderConfig();

        [OperationContract]
        bool DeletePageSpecificPlaceholderConfig(int pageSpecificPlaceholderId, SolutionEnums.PageSpecificPlaceholder pageSpecificPlaceholder);

        [OperationContract]
        int SavePageSpecificPlaceholder(PageSpecificPlaceholderConfigVM pageSpecificPlaceholderConfigVM);

        #endregion

        #region [Email Queue]

        [OperationContract]
        int UpdateEmailQueue(EmailQueueVM emailQueueVM);

        [OperationContract]
        List<EmailQueueVM> GetPendingEmailQueue();

        #endregion

        #region [Email Log]

        [OperationContract]
        int SaveEmailLog(EmailLogVM emailLogVM, int emailQueueId);

        #endregion

        #region [Process Email Template]

        [OperationContract]
        int SaveProcessEmailTemplate(ProcessEmailTemplateVM processEmailTemplateViewModel);

        [OperationContract]
        List<ProcessEmailTemplateVM> GetAllProcessEmailTemplate();

        [OperationContract]
        ProcessEmailTemplateVM GetProcessEmailTemplate(int id);

        [OperationContract]
        List<ProcessVM> GetAllProcess();

        [OperationContract]
        bool DeleteProcessEmailTemplate(int processEmailTemplateId);

        #endregion

        #region [Master Configuration]

        [OperationContract]
        int SaveMasterConfiguration(MasterConfigurationViewModel masterConfigurationViewModel);

        [OperationContract]
        MasterConfigurationViewModel GetMasterConfiguration();

        #endregion
    }
}
