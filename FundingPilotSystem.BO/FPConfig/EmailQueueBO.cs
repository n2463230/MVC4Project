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
    public class EmailQueueBO
    {
        public int Id { get; set; }
        public int Process { get; set; }
        public string Receiver { get; set; }
        public Nullable<int> UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string HouseNo { get; set; }
        public string Side { get; set; }
        public string Door { get; set; }
        public string Streetname { get; set; }
        public string AdditionalAddress_1 { get; set; }
        public string AdditionalAddress_2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Fixedphone { get; set; }
        public string MobileNo { get; set; }
        public Nullable<int> KYCStatus { get; set; }
        public Nullable<int> AccountNo { get; set; }
        public string AccountType { get; set; }
        public string AdditionalInformation1 { get; set; }
        public string AdditionalInformation2 { get; set; }
        public string AdditionalInformation3 { get; set; }
        public string AdditionalInformation4 { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ErrorStatus { get; set; }
        public string EmailContent { get; set; }
        public string ProcessName { get; set; }
    }
}
