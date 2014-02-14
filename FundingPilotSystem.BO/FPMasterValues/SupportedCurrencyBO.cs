using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.BO
{
    public class SupportedCurrencyBO
    {
        public int Id { get; set; }
        public string CurrencyISOCode { get; set; }
        public string CurrencyDescription { get; set; }
    }
}
