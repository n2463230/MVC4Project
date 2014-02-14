using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{

    /// <summary>
    /// This class provides Dto for system module
    /// </summary>
    public class tblSystemModuleDto
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public string ResourceFileName { get; set; }
        public string ResourceFolderName { get; set; }
    }
}
