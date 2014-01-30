using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain.SolutionDto
{
    public class LoggedInUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
