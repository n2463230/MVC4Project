using System.Collections.Generic;
using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;
using System.Linq;

namespace FundingPilotSystem.DAL
{
    public class EmailTemplateConfigurationProviderDAL
    {
        /// <summary>
        /// Save Process Email Template
        /// </summary>
        /// <param name="masterConfigurationBO"></param>
        /// <returns></returns>
        public int SaveProcessEmailTemplate(ProcessEmailTemplateBO processEmailTemplateBO)
        {
            Mapper.CreateMap<ProcessEmailTemplateBO, tblProcessEmailTemplateDto>();
            tblProcessEmailTemplateDto tblProcessEmailTemplateDto = new tblProcessEmailTemplateDto();

            Mapper.Map(processEmailTemplateBO, tblProcessEmailTemplateDto);
            var processEmailTemplateProvider = new ProcessEmailTemplateProvider();
            return processEmailTemplateProvider.SaveProcessEmailTemplate(tblProcessEmailTemplateDto);
        }

        /// <summary>
        /// Get All ProcessEmail Template
        /// </summary>
        /// <returns></returns>
        public List<ProcessEmailTemplateBO> GetAllProcessEmailTemplate()
        {
            var processEmailTemplateProvider = new ProcessEmailTemplateProvider();
            Mapper.CreateMap<tblProcessEmailTemplateDto, ProcessEmailTemplateBO>();
            Mapper.CreateMap<tblProcessDto, ProcessBO>();

            return Mapper.Map<List<tblProcessEmailTemplateDto>, List<ProcessEmailTemplateBO>>(processEmailTemplateProvider.GetAllProcessEmailTemplate());
        }

        /// <summary>
        /// Get ProcessEmail Template By Id
        /// </summary>
        /// <returns></returns>
        public ProcessEmailTemplateBO GetProcessEmailTemplate(int id)
        {
            var processEmailTemplateProvider = new ProcessEmailTemplateProvider();
            Mapper.CreateMap<tblProcessEmailTemplateDto, ProcessEmailTemplateBO>();
            Mapper.CreateMap<tblProcessDto, ProcessBO>();

            return Mapper.Map<tblProcessEmailTemplateDto, ProcessEmailTemplateBO>(processEmailTemplateProvider.GetProcessEmailTemplate(id));
        }

        /// <summary>
        /// Get All Process
        /// </summary>
        /// <returns></returns>
        public List<ProcessBO> GetAllProcess()
        {
            var processesProvider = new ProcessesProvider();
            Mapper.CreateMap<tblProcessDto, ProcessBO>();
            return Mapper.Map<List<tblProcessDto>, List<ProcessBO>>(processesProvider.GetAllProcess());
        }

        /// <summary>
        /// Delete  ProcessEmailTemplate
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public bool DeleteProcessEmailTemplate(int processEmailTemplateId)
        {
            var processEmailTemplateProvider = new ProcessEmailTemplateProvider();
            return processEmailTemplateProvider.DeleteProcessEmailTemplate(processEmailTemplateId);
        }
    }
}
