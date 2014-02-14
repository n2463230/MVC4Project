using System.Collections.Generic;
using FundingPilotSystem.BO;
using FundingPilotSystem.DAL;

namespace FundingPilotSystem.BLL
{
    public class EmailTemplateConfigurationProviderBLL
    {
        /// <summary>
        /// Save Process Email Template
        /// </summary>
        /// <param name="masterConfigurationBO"></param>
        /// <returns></returns>
        public int SaveProcessEmailTemplate(ProcessEmailTemplateBO processEmailTemplateBO)
        {
            var emailTemplateConfigurationProviderDAL = new EmailTemplateConfigurationProviderDAL();
            return emailTemplateConfigurationProviderDAL.SaveProcessEmailTemplate(processEmailTemplateBO);
        }

        /// <summary>
        /// Get All ProcessEmail Template
        /// </summary>
        /// <returns></returns>
        public List<ProcessEmailTemplateBO> GetAllProcessEmailTemplate()
        {
            var emailTemplateConfigurationProviderDAL = new EmailTemplateConfigurationProviderDAL();
            return emailTemplateConfigurationProviderDAL.GetAllProcessEmailTemplate();
        }

        /// <summary>
        /// Get ProcessEmail Template By Id
        /// </summary>
        /// <returns></returns>
        public ProcessEmailTemplateBO GetProcessEmailTemplate(int id)
        {
            var emailTemplateConfigurationProviderDAL = new EmailTemplateConfigurationProviderDAL();
            return emailTemplateConfigurationProviderDAL.GetProcessEmailTemplate(id);
        }

        /// <summary>
        /// Get All Process
        /// </summary>
        /// <returns></returns>
        public List<ProcessBO> GetAllProcess()
        {
            var emailTemplateConfigurationProviderDAL = new EmailTemplateConfigurationProviderDAL();
            return emailTemplateConfigurationProviderDAL.GetAllProcess();
        }

        /// <summary>
        /// Delete  ProcessEmailTemplate
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public bool DeleteProcessEmailTemplate(int processEmailTemplateId)
        {
            var emailTemplateConfigurationProviderDAL = new EmailTemplateConfigurationProviderDAL();
            return emailTemplateConfigurationProviderDAL.DeleteProcessEmailTemplate(processEmailTemplateId);
        }
    }
}
