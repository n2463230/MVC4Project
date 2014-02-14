using System;
using FundingPilotSystem.Common;

namespace FundingPilotSystem.VM
{
    public class PageSpecificPlaceholderConfigVM
    {
        #region ["Mandatory Fields in Database"]

        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string TopFrameHTML { get; set; }
        public string LeftFrameHTML { get; set; }
        public string RightFrameHTML { get; set; }
        public string BottomFrameHTML { get; set; }

        public string ModuleName { get; set; }
        #endregion

        #region ["Optional Fields in Database"]

        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }

        #endregion
    }
}