namespace FundingPilotSystem.BO
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmailLogBO
    {
        public int Id { get; set; }
        public int Process { get; set; }
        public string EmailBody { get; set; }
        public string Receiver { get; set; }
        public System.DateTime SentTime { get; set; }
    
        public virtual ProcessBO Processes { get; set; }
    }
}
