using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain.FPMasterValues
{
    public class tblCountryListDto
    {
        public int Id { get; set; }
        public string CountryISOCode { get; set; }
        public string Country { get; set; }
    }
}
