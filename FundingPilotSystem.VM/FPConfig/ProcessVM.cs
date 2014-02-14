using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.VM
{
    /// <summary>
    /// This class provides Dto for Master Configuration object
    /// </summary>
    public class ProcessVM
    {
        public ProcessVM()
        {
            this.ProcessEmailTemplates = new HashSet<ProcessEmailTemplateVM>();
            this.EmailLogs = new HashSet<EmailLogVM>();
            this.EmailQueues = new HashSet<EmailQueueVM>();
        }
    
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }

        public virtual ICollection<ProcessEmailTemplateVM> ProcessEmailTemplates { get; set; }
        public virtual ICollection<EmailLogVM> EmailLogs { get; set; }
        public virtual ICollection<EmailQueueVM> EmailQueues { get; set; }
    }
}
