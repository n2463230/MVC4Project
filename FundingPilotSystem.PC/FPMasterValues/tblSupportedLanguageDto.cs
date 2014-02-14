using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{
    /// <summary>
    /// This class provides Dto for Supported language
    /// </summary>
    public class tblSupportedLanguageDto
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string LanguageCode { get; set; }
    }
}
