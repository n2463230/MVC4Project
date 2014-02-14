using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{

    /// <summary>
    /// This class provides Dto for user login credentials
    /// </summary>
   public class tblUserLoginCredentialsDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] LoginPassword { get; set; }
        public Nullable<System.DateTime> LastPasswordChanged { get; set; }
        public Nullable<System.DateTime> LastFailedLogin { get; set; }
        public Nullable<int> FailedLoginCount { get; set; }
        public bool IsLocked { get; set; }
        public int UserType { get; set; }
        public byte[] Key { get; set; }
        public byte[] Salt { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }

    }
}
