using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using FundingPilotSystem.Common;


namespace FundingPilotSystem.VM
{
    [DataContract()] 
    public class UserRegistrationRequestsViewModel : CommonModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [LocalizedDisplayNameAttribute("RegistrationProcess", "UserEmail")]
        [CustomRequiredAttribute("RegistrationProcess", "ValidationEmailisRequired")]
        [EmailAddress]
        public string UserEmailAddress { get; set; }

        [DataMember]
        public byte[] UserEmail { get; set; }

        [DataMember]
        public byte[] LoginPassword { get; set; }

        [DataMember]
        [CustomRequiredAttribute("RegistrationProcess", "ValidationPasswordIsRequired")]
        [DataType(DataType.Password)]
        [LocalizedDisplayNameAttribute("RegistrationProcess", "Password")]

        public string Password { get; set; }

        [DataMember]
        [CustomRequiredAttribute("RegistrationProcess", "ValidateConfirmPasswordIsRequired")]
        [DataType(DataType.Password)]
        [CustomCompareAttribute("Password")]
        [LocalizedDisplayNameAttribute("RegistrationProcess", "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [DataMember]
        [LocalizedDisplayNameAttribute("RegistrationProcess", "NewsletterSubsicription")]
        public bool NewsLetter { get; set; }

        [DataMember]
        public System.DateTime RegistrationDate { get; set; }

        [DataMember]
        public int UserStatus { get; set; }

        [DataMember]
        public string RegistrationIP { get; set; }

        [DataMember]
        [LocalizedDisplayNameAttribute("RegistrationProcess", "ResidingCountry")]
        [CustomRequiredAttribute("RegistrationProcess", "ValidateCountryOfResidence")]
        public int CountryOfRegistration { get; set; }

        [DataMember]
        public List<CountryOfOperationVM> CountriesOfOperation { get; set; }
       

        public AlertModel AlertModel { get; set; }
    }
}
