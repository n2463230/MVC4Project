using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain.FPUserProfile
{
    public class tblUserRegistrationRequestDto
    {
        public int Id { get; set; }
        public byte[] UserEmail { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public int UserStatus { get; set; }
        public string RegistrationIP { get; set; }
        public int CountryOfRegistration { get; set; }
        public bool NewsLetter { get; set; }
        public byte[] LoginPassword { get; set; }
    }
}
