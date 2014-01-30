using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain.SolutionDto
{
    public class ResourceData
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string NewValue { get; set; }
        public string ModuleName { get; set; }
        public int ModuleId { get; set; }
    }
}
