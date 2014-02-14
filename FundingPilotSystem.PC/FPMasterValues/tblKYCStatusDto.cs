using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{

    /// <summary>
    /// This class provides Dto for user KYC Status
    /// </summary>
    public class tblKYCStatusDto
    {
        public int Id { get; set; }
        public string KYCStatus { get; set; }
    }
}
