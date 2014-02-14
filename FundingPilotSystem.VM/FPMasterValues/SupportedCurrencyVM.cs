using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.VM
{
    public class SupportedCurrencyVM
    {
        public int Id { get; set; }
        public string CurrencyISOCode { get; set; }
        public string CurrencyDescription { get; set; }
    }
}
