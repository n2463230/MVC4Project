namespace FundingPilotSystem.VM
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmailLogVM
    {
        public int Id { get; set; }
        public int Process { get; set; }
        public string EmailBody { get; set; }
        public string Receiver { get; set; }
        public System.DateTime SentTime { get; set; }
    
        public virtual ProcessVM Processes { get; set; }
    }
}
