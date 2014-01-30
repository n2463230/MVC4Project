using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain.FPMasterValues
{
    public class tblCountryOfOperationDto
    {
        public int Id { get; set; }
        public string CountryISOCode { get; set; }
        public string CountryName { get; set; }
        public int DefaultLanguageId { get; set; }
        public int DefaultCurrencyId { get; set; }
    }
}
