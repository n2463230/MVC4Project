namespace FundingPilotSystem.Domain
{
    using System;
    using System.Collections.Generic;

    public partial class tblProcessEmailTemplateDto
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public string EmailContent { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }

        public virtual tblProcessDto tblProcess { get; set; }
    }
}
