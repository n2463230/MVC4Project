using AutoMapper;
using System.Collections.Generic;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore.ORM;
using FundingPilotSystem.Common;
using System.Linq;

namespace FundingPilotSystem.UnifiedDataStore
{
    public class PageSpecificPlaceholderConfigProvider
    {
        /// <summary>
        /// Returns list of static html page
        /// </summary>
        /// <returns></returns>
        public List<tblPageSpecificPlaceholderConfigDto> GetAllPageSpecificPlaceholderConfig()
        {
            var pageSpecificPlaceholderConfigDto = new List<tblPageSpecificPlaceholderConfigDto>();
            using (var dbFPConfig = new FPConfigEntities())
            {
                Mapper.CreateMap<tblPageSpecificPlaceholderConfig, tblPageSpecificPlaceholderConfigDto>();

                var pageSpecificPlaceholderConfigList = dbFPConfig.tblPageSpecificPlaceholderConfigs;

                if (pageSpecificPlaceholderConfigList != null)
                {
                    Mapper.Map(pageSpecificPlaceholderConfigList, pageSpecificPlaceholderConfigDto);
                }
            }
            return pageSpecificPlaceholderConfigDto;
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="tblPageSpecificPlaceholderConfigDto"></param>
        /// <returns></returns>
        public int SavePageSpecificPlaceholder(tblPageSpecificPlaceholderConfigDto tblPageSpecificPlaceholderConfigDto)
        {
            using (var fpCofigDataContext = new FPConfigEntities())
            {
                int result = 0;

                Mapper.CreateMap<tblPageSpecificPlaceholderConfigDto, tblPageSpecificPlaceholderConfig>();

                //update
                if (tblPageSpecificPlaceholderConfigDto.Id > 0)
                {
                    var tblPageSpecificPlaceholderConfig = fpCofigDataContext.tblPageSpecificPlaceholderConfigs.Find(tblPageSpecificPlaceholderConfigDto.Id);
                    tblPageSpecificPlaceholderConfigDto.CreatedBy = tblPageSpecificPlaceholderConfig.CreatedBy;
                    tblPageSpecificPlaceholderConfigDto.CreatedOn = tblPageSpecificPlaceholderConfig.CreatedOn;

                    Mapper.Map(tblPageSpecificPlaceholderConfigDto, tblPageSpecificPlaceholderConfig);
                    fpCofigDataContext.SaveChanges();
                    result = tblPageSpecificPlaceholderConfig.Id;
                }//add
                else
                {
                    var tblPageSpecificPlaceholderConfig = new tblPageSpecificPlaceholderConfig();
                    Mapper.Map(tblPageSpecificPlaceholderConfigDto, tblPageSpecificPlaceholderConfig);
                    fpCofigDataContext.tblPageSpecificPlaceholderConfigs.Add(tblPageSpecificPlaceholderConfig);
                    fpCofigDataContext.SaveChanges();
                    result = tblPageSpecificPlaceholderConfig.Id;
                }
                return result;
            }
        }

        /// <summary>
        /// Delete page specfic place holder
        /// </summary>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <returns></returns>
        public bool DeletePageSpecificPlaceholderConfig(int pageSpecificPlaceholderId, SolutionEnums.PageSpecificPlaceholder pageSpecificPlaceholder)
        {
            int result = 0;
            using (var fpCofigDataContext = new FPConfigEntities())
            {
                var pageSpecificTempletePlaceHolder = fpCofigDataContext.tblPageSpecificPlaceholderConfigs.Find(pageSpecificPlaceholderId);
                switch (pageSpecificPlaceholder)
                {
                    case SolutionEnums.PageSpecificPlaceholder.Top:
                        pageSpecificTempletePlaceHolder.TopFrameHTML = string.Empty;
                        break;
                    case SolutionEnums.PageSpecificPlaceholder.Left:
                        pageSpecificTempletePlaceHolder.LeftFrameHTML = string.Empty;
                        break;
                    case SolutionEnums.PageSpecificPlaceholder.Right:
                        pageSpecificTempletePlaceHolder.RightFrameHTML = string.Empty;
                        break;
                    case SolutionEnums.PageSpecificPlaceholder.Bottom:
                        pageSpecificTempletePlaceHolder.BottomFrameHTML = string.Empty;
                        break;
                }
                result = fpCofigDataContext.SaveChanges();
            }
            return true;
        }
    }
}