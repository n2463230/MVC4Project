using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{
    public class tblPageSpecificPlaceholderConfigDto
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string TopFrameHTML { get; set; }
        public string LeftFrameHTML { get; set; }
        public string RightFrameHTML { get; set; }
        public string BottomFrameHTML { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }
    }
}