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
    
    public partial class tblUserRegistrationRequest
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
