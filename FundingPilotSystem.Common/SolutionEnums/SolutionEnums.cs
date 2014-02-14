using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Common
{
    public class SolutionEnums
    {
        public enum UserRegistrationStatus
        {
            InProgress = 1,
            Confirmed,
            Cancelled
        }

        public enum PageSpecificPlaceholder
        {
            Top = 1,
            Left,
            Right,
            Bottom
        }
    }
}
