using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.VM
{
    public class ResourceDataVM
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string NewValue { get; set; }
        public string ModuleName { get; set; }
        public int ModuleId { get; set; }
        public string CultureValue { get; set; }
    }
}
