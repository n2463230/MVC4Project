using AutoMapper;
using FundingPilotSystem.Domain;
using System.Linq;
using System.Collections.Generic;

using FundingPilotSystem.UnifiedDataStore.ORM;

namespace FundingPilotSystem.UnifiedDataStore
{
    /// <summary>
    /// Peforms process email tempate retated operations
    /// </summary>
    public class ProcessEmailTemplateProvider
    {
        /// <summary>
        /// Get email template
        /// </summary>
        /// <returns></returns>
        public List<tblProcessEmailTemplateDto> GetAllProcessEmailTemplate()
        {
            using (var FPConfigEntitiesDataContext = new FPConfigEntities())
            {
                Mapper.CreateMap<tblProcessEmailTemplate, tblProcessEmailTemplateDto>();
                Mapper.CreateMap<tblProcess, tblProcessDto>();

                return Mapper.Map<List<tblProcessEmailTemplate>, List<tblProcessEmailTemplateDto>>(FPConfigEntitiesDataContext.tblProcessEmailTemplates.ToList());
            }
        }

        /// <summary>
        /// Get Process Email Template By Id
        /// </summary>
        /// <returns></returns>
        public tblProcessEmailTemplateDto GetProcessEmailTemplate(int id)
        {
            using (var FPConfigEntitiesDataContext = new FPConfigEntities())
            {
                Mapper.CreateMap<tblProcessEmailTemplate, tblProcessEmailTemplateDto>();
                Mapper.CreateMap<tblProcess, tblProcessDto>();
                var processEmailTemplate = FPConfigEntitiesDataContext.tblProcessEmailTemplates.Find(id);
                return Mapper.Map(processEmailTemplate, new tblProcessEmailTemplateDto());
            }
        }

        /// <summary>
        /// Saves/Updates ProcessEmailTemplate
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public int SaveProcessEmailTemplate(tblProcessEmailTemplateDto processEmailTemplateDto)
        {
            Mapper.CreateMap<tblProcessEmailTemplateDto, tblProcessEmailTemplate>()
                .ForMember(dest => dest.tblProcess, opt => opt.Ignore());

            int result = 0;
            try
            {
                using (var FPConfigEntities = new FPConfigEntities())
                {
                    var processEmailTemplate = new tblProcessEmailTemplate();
                    //Update mode
                    if (processEmailTemplateDto.Id > 0)
                    {
                        processEmailTemplate = FPConfigEntities.tblProcessEmailTemplates.Find(processEmailTemplateDto.Id);
                        Mapper.Map(processEmailTemplateDto, processEmailTemplate);
                        result = FPConfigEntities.SaveChanges();
                    }
                    //New configuration 
                    else
                    {
                        Mapper.Map(processEmailTemplateDto, processEmailTemplate);
                        FPConfigEntities.tblProcessEmailTemplates.Add(processEmailTemplate);
                        result = FPConfigEntities.SaveChanges();
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
        /// Delete  ProcessEmailTemplate
        /// </summary>
        /// <param name="masterConfigDto"></param>
        /// <returns>int</returns>
        public bool DeleteProcessEmailTemplate(int processEmailTemplateId)
        {
            try
            {
                using (var FPConfigEntities = new FPConfigEntities())
                {
                    var processEmailTemplate = FPConfigEntities.tblProcessEmailTemplates.Find(processEmailTemplateId);
                    if (processEmailTemplateId > 0)
                    {
                        FPConfigEntities.tblProcessEmailTemplates.Remove(processEmailTemplate);
                        FPConfigEntities.SaveChanges();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
