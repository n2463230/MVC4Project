using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.VM.FPUserProfile
{
    public class RegisteredUserViewModel
    {
        #region ["Mandatory Properties"]

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public byte[] UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [Required]
        public int CountryOfRegistration { get; set; }

        [Required]
        public bool NewsLetter { get; set; }

        public System.DateTime RegistrationDate { get; set; }

        public string RegistrationIP { get; set; }

        public System.DateTime ConfirmationDate { get; set; }

        public byte[] ConfirmationIP { get; set; }

        #endregion

        #region ["Optional Properties"]

        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }

        #endregion
    }
}
