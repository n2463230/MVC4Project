using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{

    /// <summary>
    /// This class provides Dto for country of operations
    /// </summary>
    public class tblCountryOfOperationDto
    {
        public int Id { get; set; }
        public string CountryISOCode { get; set; }
        public string CountryName { get; set; }
        public int DefaultLanguageId { get; set; }
        public int DefaultCurrencyId { get; set; }
    }
}
