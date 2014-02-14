using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.Common;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;
using System.Collections.Generic;
using System.Linq;

namespace FundingPilotSystem.DAL
{
    public class PageSpecificPlaceholderConfigProviderDAL
    {
        /// <summary>
        /// Get list of static html pages
        /// </summary>
        /// <returns></returns>
        public List<PageSpecificPlaceholderConfigBO> GetAllPageSpecificPlaceholderConfig()
        {
            var pageSpecificPlaceholderConfigProvider = new PageSpecificPlaceholderConfigProvider();
            var masterDataProvider = new MasterDataProvider();

            var systemModulesList = masterDataProvider.GetSystemModules();
            var pageSpecificPlaceholderConfigList = pageSpecificPlaceholderConfigProvider.GetAllPageSpecificPlaceholderConfig();

            return (from systemModule in systemModulesList
                    join pageSpecificPlaceholderConfig in pageSpecificPlaceholderConfigList
                        on systemModule.Id equals pageSpecificPlaceholderConfig.ModuleId into pageSpecificPlaceholderConfigListLeft
                    from pageSpecificConfig in pageSpecificPlaceholderConfigListLeft.DefaultIfEmpty()
                    select new PageSpecificPlaceholderConfigBO
                    {
                        Id = pageSpecificConfig == null ? 0 : pageSpecificConfig.Id,
                        ModuleId = systemModule.Id,
                        ModuleName = systemModule.Module,
                        TopFrameHTML = pageSpecificConfig == null ? string.Empty : pageSpecificConfig.TopFrameHTML,
                        LeftFrameHTML = pageSpecificConfig == null ? string.Empty : pageSpecificConfig.LeftFrameHTML,
                        RightFrameHTML = pageSpecificConfig == null ? string.Empty : pageSpecificConfig.RightFrameHTML,
                        BottomFrameHTML = pageSpecificConfig == null ? string.Empty : pageSpecificConfig.BottomFrameHTML
                    }).ToList();
        }

        /// <summary>
        /// Delete page specfic place holder to set empty string to place holder
        /// </summary>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <returns></returns>
        public bool DeletePageSpecificPlaceholderConfig(int pageSpecificPlaceholderId, SolutionEnums.PageSpecificPlaceholder pageSpecificPlaceholder)
        {
            var pageSpecificPlaceholderConfigProvider = new PageSpecificPlaceholderConfigProvider();
            return pageSpecificPlaceholderConfigProvider.DeletePageSpecificPlaceholderConfig(pageSpecificPlaceholderId, pageSpecificPlaceholder);
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="tblPageSpecificPlaceholderConfigDto"></param>
        /// <returns></returns>
        public int SavePageSpecificPlaceholder(PageSpecificPlaceholderConfigBO pageSpecificPlaceholderConfigBO)
        {
            Mapper.CreateMap<PageSpecificPlaceholderConfigBO, tblPageSpecificPlaceholderConfigDto>();
            var tblPageSpecificPlaceholderConfigDto = new tblPageSpecificPlaceholderConfigDto();
            Mapper.Map(pageSpecificPlaceholderConfigBO, tblPageSpecificPlaceholderConfigDto);
            var pageSpecificPlaceholderConfigProvider = new PageSpecificPlaceholderConfigProvider();

            return pageSpecificPlaceholderConfigProvider.SavePageSpecificPlaceholder(tblPageSpecificPlaceholderConfigDto);
        }
    }
}