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
    
    public partial class tblProcess
    {
        public tblProcess()
        {
            this.tblProcessEmailTemplates = new HashSet<tblProcessEmailTemplate>();
            this.tblEmailLogs = new HashSet<tblEmailLog>();
            this.tblEmailQueues = new HashSet<tblEmailQueue>();
        }
    
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }
    
        public virtual ICollection<tblProcessEmailTemplate> tblProcessEmailTemplates { get; set; }
        public virtual ICollection<tblEmailLog> tblEmailLogs { get; set; }
        public virtual ICollection<tblEmailQueue> tblEmailQueues { get; set; }
    }
}
