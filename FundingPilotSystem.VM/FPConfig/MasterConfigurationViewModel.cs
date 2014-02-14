using FundingPilotSystem.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace FundingPilotSystem.VM
{
    public class MasterConfigurationViewModel : CommonModel
    {
        #region ["Mandatory Fields in Database"]

        public int Id { get; set; }

        [CustomRangeAttribute(2, 15, "CommonResource", "ValidationRangeBetween2To15")]
        [CustomRequiredAttribute("SystemConfigurationResources", "ValidationRequiredMinPasswordLength")]
        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "MinPasswordLength")]
        public Int32 MinPasswordLength { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "MaxPasswordLife")]
        [CustomRequiredAttribute("SystemConfigurationResources", "ValidationRequiredMaxPasswordLife")]
        [CustomRangeAttribute(1, 999, "CommonResource", "ValidationRangeBetween1To999")]
        public Int32 MaxPasswordLife { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "MaxLogonRetry")]
        [CustomRequiredAttribute("SystemConfigurationResources", "ValidationRequiredMaxLogonRetry")]
        [CustomRangeAttribute(2, 20, "CommonResource", "ValidationRangeBetween2To20")]
        public Int32 MaxLogonRetry { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "PasswordHistoryCount")]
        [CustomRequiredAttribute("SystemConfigurationResources", "ValidationRequiredPasswordHistoryCount")]
        public Int32 PasswordHistoryCount { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "RequireNumberInPassword")]
        public bool RequireNumberInPassword { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "RequireSpecialCharacterInPassword")]
        public Boolean RequireSpecialCharacterInPassword { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "AllowReusePasswordFromHistory")]
        public Boolean AllowReusePasswordFromHistory { get; set; }

        public String CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        #endregion

        #region ["Optional Fields in Database"]

        public String ModifiedBy { get; set; }

        public Nullable<DateTime> ModifiedOn { get; set; }

        public String IPAddressOfLastAction { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "DefaultEmailAddress")]
        [CustomStringLengthAttribute(255, "CommonResource", "ValidationRange0To255")]
        [CustomRegularExpressionAttribute("^[A-Za-z0-9_\\+-]+(\\.[A-Za-z0-9_\\+-]+)*@[A-Za-z0-9]+(\\.[A-Za-z0-9]+)*\\.([A-Za-z]{2,4})$", "SystemConfigurationResources", "ValidationRequiredValidEmailAddress")]
        public string DefaultEmailAddress { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "OutgoingEmailServer")]
        [CustomRegularExpressionAttribute("^[0-9a-zA-Z_.]+$", "CommonResource", "ValidationInvalidCharacters")]
        [CustomStringLengthAttribute(255, "CommonResource", "ValidationRange0To255")]
        public string OutgoingEmailServer { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "SenderEmailAddress")]
        [CustomStringLengthAttribute(255, "CommonResource", "ValidationRange0To255")]
        [CustomRegularExpressionAttribute("^[A-Za-z0-9_\\+-]+(\\.[A-Za-z0-9_\\+-]+)*@[A-Za-z0-9]+(\\.[A-Za-z0-9]+)*\\.([A-Za-z]{2,4})$", "SystemConfigurationResources", "ValidationRequiredValidEmailAddress")]
        public string SenderMailAddress { get; set; }

        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "EmailAccountUserName")]
        [CustomRegularExpressionAttribute("^[0-9a-zA-Z_.]+$", "CommonResource", "ValidationInvalidCharacters")]
        [CustomStringLengthAttribute(50, "CommonResource", "ValidationRange0To255")]
        public string EmailAccountUserName { get; set; }

        [DataType(DataType.Password)]
        [LocalizedDisplayNameAttribute("SystemConfigurationResources", "EmailAccountPassword")]
        public string EmailAccountUserPassword { get; set; }

        #endregion
    }
}
