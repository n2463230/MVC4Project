//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FundingPilotSystem.UnifiedDataStore.ORM
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRegisteredUser
    {
        public int Id { get; set; }
        public byte[] UserEmail { get; set; }
        public int CountryOfRegistration { get; set; }
        public bool NewsLetter { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string RegistrationIP { get; set; }
        public System.DateTime ConfirmationDate { get; set; }
        public string ConfirmationIP { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }
    }
}