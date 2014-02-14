using FundingPilotSystem.Common;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FundingPilotSystem.VM
{
    public class LocalizationSettingsVM :CommonModel
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string ResourceFileName { get; set; }
        public string ResourceFolderName { get; set; }

        public List<SelectListItem> SystemModuleDDL { get; set; }
        public List<SelectListItem> Cultures { get; set; }

        public string SelectedCulture { get; set; }
        public string SelectedModule { get; set; }
    }
}
