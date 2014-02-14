using FundingPilotSystem.BO;
using FundingPilotSystem.Common;
using FundingPilotSystem.DAL;
using System.Collections.Generic;

namespace FundingPilotSystem.BLL
{
    public class PageSpecificPlaceholderConfigBLL
    {
        /// <summary>
        /// Get list of static html pages
        /// </summary>
        /// <returns></returns>
        public List<PageSpecificPlaceholderConfigBO> GetAllPageSpecificPlaceholderConfig()
        {
            var pageSpecificPlaceholderConfigProviderDAL = new PageSpecificPlaceholderConfigProviderDAL();
            return pageSpecificPlaceholderConfigProviderDAL.GetAllPageSpecificPlaceholderConfig();
        }

        /// <summary>
        /// Delete page specfic place holder to set empty string to place holder
        /// </summary>
        /// <param name="pageSpecificPlaceholderId"></param>
        /// <param name="pageSpecificPlaceholder"></param>
        /// <returns></returns>
        public bool DeletePageSpecificPlaceholderConfig(int pageSpecificPlaceholderId, SolutionEnums.PageSpecificPlaceholder pageSpecificPlaceholder)
        {
            var pageSpecificPlaceholderConfigProviderDAL = new PageSpecificPlaceholderConfigProviderDAL();
            return pageSpecificPlaceholderConfigProviderDAL.DeletePageSpecificPlaceholderConfig(pageSpecificPlaceholderId, pageSpecificPlaceholder);
        }

        /// <summary>
        /// Save Page Specific Placeholder
        /// </summary>
        /// <param name="tblPageSpecificPlaceholderConfigDto"></param>
        /// <returns></returns>
        public int SavePageSpecificPlaceholder(PageSpecificPlaceholderConfigBO pageSpecificPlaceholderConfigBO)
        {
            var pageSpecificPlaceholderConfigProviderDAL = new PageSpecificPlaceholderConfigProviderDAL();
            return pageSpecificPlaceholderConfigProviderDAL.SavePageSpecificPlaceholder(pageSpecificPlaceholderConfigBO);
        }
    }
}