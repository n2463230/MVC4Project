using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{
    /// <summary>
    /// This class provides Dto for Master Configuration object
    /// </summary>
    public class tblProcessDto
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }
    }
}
