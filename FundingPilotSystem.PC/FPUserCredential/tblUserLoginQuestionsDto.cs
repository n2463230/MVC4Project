using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain.FPUserCredential
{
   public class tblUserLoginQuestionsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] SecretQuestion { get; set; }
        public byte[] Answer { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }
    }
}
