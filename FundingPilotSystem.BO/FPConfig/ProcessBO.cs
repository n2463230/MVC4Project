using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.BO
{
    /// <summary>
    /// This class provides Dto for Master Configuration object
    /// </summary>
    public class ProcessBO
    {
        public ProcessBO()
        {
            this.ProcessEmailTemplates = new HashSet<ProcessEmailTemplateBO>();
            this.EmailLogs = new HashSet<EmailLogBO>();
            this.EmailQueues = new HashSet<EmailQueueBO>();
        }
    
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }

        public virtual ICollection<ProcessEmailTemplateBO> ProcessEmailTemplates { get; set; }
        public virtual ICollection<EmailLogBO> EmailLogs { get; set; }
        public virtual ICollection<EmailQueueBO> EmailQueues { get; set; }
    }
}
