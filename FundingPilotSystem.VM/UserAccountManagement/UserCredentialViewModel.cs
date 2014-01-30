using FundingPilotSystem.Domain;
using FundingPilotSystem.Domain.SolutionUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.VM.UserAccountManagement
{
    public class UserCredentialViewModel
    {              

        #region ["Mandatory Properties"]

        //public int Id { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public int UserId { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public byte[] LoginPassword { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public bool IsLocked { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public int UserType { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public byte[] Key { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public byte[] Salt { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public string CreatedBy { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("", "")]
        public System.DateTime CreatedOn { get; set; }   

        #endregion

        #region ["Optional"]

        public Nullable<System.DateTime> LastPasswordChanged { get; set; }
        public Nullable<System.DateTime> LastFailedLogin { get; set; }
        public Nullable<int> FailedLoginCount { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }

        #endregion

     
    }
}
