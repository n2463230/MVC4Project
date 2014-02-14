
using FundingPilotSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.VM
{
    public class LoginViewModel
    {
        public int UserId { get; set; }

        [Required]
        [LocalizedDisplayNameAttribute("UserAccountManagement", "UserName")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [LocalizedDisplayNameAttribute("UserAccountManagement", "Password")]
        public string Password { get; set; }
    }
}
