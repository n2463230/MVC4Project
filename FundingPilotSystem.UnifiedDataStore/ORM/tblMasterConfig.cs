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
    
    public partial class tblMasterConfig
    {
        public int Id { get; set; }
        public int MinPasswordLength { get; set; }
        public bool RequireNumberInPassword { get; set; }
        public bool RequireSpecialCharacterInPassword { get; set; }
        public int MaxPasswordLife { get; set; }
        public int MaxLogonRetry { get; set; }
        public int PasswordHistoryCount { get; set; }
        public bool AllowReusePasswordFromHistory { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }
        public string DefaultEmailAddress { get; set; }
        public string OutgoingEmailServer { get; set; }
        public string SenderMailAddress { get; set; }
        public string EmailAccountUserName { get; set; }
        public string EmailAccountUserPassword { get; set; }
    }
}
