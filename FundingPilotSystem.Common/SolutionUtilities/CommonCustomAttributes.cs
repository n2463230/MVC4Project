using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FundingPilotSystem.Common
{
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public CustomRequiredAttribute(string resourceFileName, string resourceTag)
        {
            ErrorMessage = GetMessageFromResource(resourceFileName, resourceTag);
        }
        private static String GetMessageFromResource(string resourceFileName, String resourceTag)
        {
            return CustomLocalizationUtility.GetKeyValue(HttpContext.Current, resourceFileName, resourceTag);
        }
    }

    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        public LocalizedDisplayNameAttribute(string resourceFileName, string keyName)
            : base(GetMessageFromResource(resourceFileName, keyName))
        { }

        private static string GetMessageFromResource(string resourceFileName, string keyName)
        {
            return CustomLocalizationUtility.GetKeyValue(HttpContext.Current, resourceFileName, keyName);
        }
    }

    public class CustomRangeAttribute : RangeAttribute, IClientValidatable
    {
        private double _Minimum;
        private double _Maximum;
        private string _ResourceFileName;
        private string _KeyName;
        public CustomRangeAttribute(double minimum, double maximum, string resourceFileName, string keyName)
            : base(minimum, maximum)
        {
            _Minimum = minimum;
            _Maximum = maximum;
            _ResourceFileName = resourceFileName;
            _KeyName = keyName;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            double valueObject;
            Double.TryParse(Convert.ToString(value), out  valueObject);
            return _Minimum <= valueObject && valueObject <= _Maximum;
        }

        public override string FormatErrorMessage(string name)
        {
            return GetMessageFromResource(_ResourceFileName, _KeyName);
        }

        private static String GetMessageFromResource(string resourceFileName, String resourceTag)
        {
            return CustomLocalizationUtility.GetKeyValue(HttpContext.Current, resourceFileName, resourceTag);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("range", string.Format("{0}~{1}", Minimum, Maximum));
            rule.ValidationType = "customrange";
            yield return rule;
        }
    }

    public class CustomStringLengthAttribute : StringLengthAttribute, IClientValidatable
    {
        public int MaximumLength;
        public string ResourceFileName;
        public string KeyName;

        public CustomStringLengthAttribute(int maximumLength, string resourceFileName, string keyName)
            : base(maximumLength)
        {
            MaximumLength = maximumLength;
            ResourceFileName = resourceFileName;
            KeyName = keyName;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            int valueObject = Convert.ToString(value).Length;
            return valueObject <= MaximumLength;
        }
        public override string FormatErrorMessage(string name)
        {
            return GetMessageFromResource(ResourceFileName, KeyName);
        }
        private static String GetMessageFromResource(string resourceFileName, String resourceTag)
        {
            return CustomLocalizationUtility.GetKeyValue(HttpContext.Current, resourceFileName, resourceTag);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("maximumlength", MaximumLength);
            rule.ValidationType = "customstringlength";
            yield return rule;
        }
    }

    public class CustomRegularExpressionAttribute : RegularExpressionAttribute, IClientValidatable
    {
        private string Pattern;
        private string ResourceFileName;
        private string KeyName;

        public CustomRegularExpressionAttribute(string pattern, string resourceFileName, string keyName)
            : base(pattern)
        {
            Pattern = pattern;
            ResourceFileName = resourceFileName;
            KeyName = keyName;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            Match match = Regex.Match(Convert.ToString(value), Pattern, RegexOptions.IgnoreCase);

            return match.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return GetMessageFromResource(ResourceFileName, KeyName);
        }
        private static String GetMessageFromResource(string resourceFileName, String resourceTag)
        {
            return CustomLocalizationUtility.GetKeyValue(HttpContext.Current, resourceFileName, resourceTag);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("pattern", Pattern);
            rule.ValidationType = "customregularexpression";
            yield return rule;
        }
    }

    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomCompareAttribute : ValidationAttribute
    {
        public string OtherProperty { get; set; }

        public CustomCompareAttribute(string otherProperty)
        {
            if (otherProperty == null)
                throw new ArgumentNullException("otherProperty");

            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            var otherPropertyStringValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null).ToString();

            if (!Equals(value.ToString(), otherPropertyStringValue))
            {
                return new ValidationResult(String.Format(CustomLocalizationUtility.GetKeyValue(HttpContext.Current, "CommonResource", "ValidateCompareProperties"), validationContext.DisplayName, OtherProperty));
            }
            return null;
        }
    }

    ///// <summary>
    ///// Custom validation to validate the password entered in current password and logged in password
    ///// </summary>
    //public class CheckCurrentPassword : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object password, ValidationContext validationContext)
    //    {
    //        bool isValid = System.String.CompareOrdinal(Domain.Encryption.Encrypt(Convert.ToString(password)), ICLComApplicationWebUI.CurrentContextUser.Password) == 0;

    //        if (isValid)
    //        {
    //            return ValidationResult.Success;
    //        }
    //        else
    //        {
    //            return new ValidationResult(ICLComResource.validationCustomCurrentPasswordLoginPasswordMatch);

    //        }
    //    }
    //}

    ///// <summary>
    ///// Custom validation for checking the password strength of the entered password
    ///// </summary>
    //public class MinPasswordLengthValidation : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object password, ValidationContext validationContext)
    //    {

    //        var systemConfigurationBusinessLogic = new SystemConfigurationBusinessLogic();
    //        var systemConfiguration = systemConfigurationBusinessLogic.GetSystemConfiguration();
    //        if (systemConfiguration == null)
    //        {
    //            return ValidationResult.Success;
    //        }
    //        else
    //        {
    //            if (Convert.ToString(password).Length < systemConfiguration.MinPasswordLength)
    //            {
    //                return new ValidationResult(string.Format(ICLComResource.validationCustomPasswordLengthRule, systemConfiguration.MinPasswordLength));
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }
    //}

    ///// <summary>
    ///// Custom validation for checking the password strength of the entered password
    ///// </summary>
    //public class RequireNumberInPasswordValidation : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object password, ValidationContext validationContext)
    //    {

    //        var systemConfigurationBusinessLogic = new SystemConfigurationBusinessLogic();
    //        var systemConfiguration = systemConfigurationBusinessLogic.GetSystemConfiguration();
    //        if (systemConfiguration == null)
    //        {
    //            return ValidationResult.Success;
    //        }
    //        else
    //        {
    //            if (systemConfiguration.RequireNumberInPassword)
    //            {
    //                char[] numbers = "123456789".ToCharArray();
    //                int indexOf = password.ToString().IndexOfAny(numbers);
    //                if (indexOf == -1)
    //                {
    //                    return new ValidationResult(ICLComResource.validationCustomPasswordNumberRule);

    //                }
    //            }
    //            if (!systemConfiguration.RequireNumberInPassword)
    //            {
    //                char[] numbers = "123456789".ToCharArray();
    //                int indexOf = password.ToString().IndexOfAny(numbers);
    //                if (indexOf > 0)
    //                {
    //                    return new ValidationResult(ICLComResource.validationCustomPasswordNotContainNumberRule);
    //                }
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }

    //}

    ///// <summary>
    ///// Custom validation for checking the password strength of the entered password
    ///// </summary>
    //public class RequireSpecialCharacterInPasswordValidation : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object password, ValidationContext validationContext)
    //    {

    //        var systemConfigurationBusinessLogic = new SystemConfigurationBusinessLogic();
    //        var systemConfiguration = systemConfigurationBusinessLogic.GetSystemConfiguration();
    //        if (systemConfiguration == null)
    //        {
    //            return ValidationResult.Success;
    //        }
    //        else
    //        {
    //            if (!systemConfiguration.RequireSpecialCharacterInPassword)
    //            {
    //                char[] numbers = "!@#$%^&*()".ToCharArray();
    //                int indexOf = password.ToString().IndexOfAny(numbers);
    //                if (indexOf > 0)
    //                {
    //                    return new ValidationResult(ICLComResource.validationCustomPasswordNotContainSpecialChar);

    //                }
    //            }
    //            if (systemConfiguration.RequireSpecialCharacterInPassword)
    //            {
    //                char[] numbers = "!@#$%^&*()".ToCharArray();
    //                int indexOf = password.ToString().IndexOfAny(numbers);
    //                if (indexOf == -1)
    //                {
    //                    return new ValidationResult(ICLComResource.validationCustomPasswordContainSpecialChar);

    //                }
    //            }

    //        }
    //        return ValidationResult.Success;
    //    }

    //}

    ///// <summary>
    ///// Custom validation for checking password from history of user passwords
    ///// </summary>
    //public class AllowPasswordFromHistoryValidation : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object password, ValidationContext validationContext)
    //    {
    //        var systemConfigurationBusinessLogic = new SystemConfigurationBusinessLogic();
    //        var systemConfiguration = systemConfigurationBusinessLogic.GetSystemConfiguration();
    //        if (systemConfiguration == null)
    //        {
    //            return ValidationResult.Success;
    //        }
    //        else
    //        {
    //            if (!systemConfiguration.AllowReusePasswordFromHistory)
    //            {
    //                bool isCurrentPassword = System.String.CompareOrdinal(Domain.Encryption.Encrypt(Convert.ToString(password)), ICLComApplicationWebUI.CurrentContextUser.Password) == 0;

    //                if (isCurrentPassword)
    //                {
    //                    return new ValidationResult(string.Format(ICLComResource.validationCustomPasswordHistoryRule, systemConfiguration.PasswordHistoryCount));
    //                }

    //                var userManagementBusinessLogic = new UserManagementBusinessLogic();
    //                var getUserPasswordHistory = userManagementBusinessLogic.GetPasswordHistory(ICLComApplicationWebUI.CurrentContextUser.UserId);

    //                if (getUserPasswordHistory != null)
    //                {
    //                    if (getUserPasswordHistory.Count < systemConfiguration.PasswordHistoryCount)
    //                    {
    //                        foreach (var tblSecUserPasswordHistoryDto in getUserPasswordHistory)
    //                        {
    //                            bool isPasswordFromHistory = System.String.CompareOrdinal(Convert.ToString(password).Encrypt(), tblSecUserPasswordHistoryDto.OldPassword) == 0;
    //                            if (isPasswordFromHistory)
    //                            {
    //                                return new ValidationResult(string.Format(ICLComResource.validationCustomPasswordHistoryRule, systemConfiguration.PasswordHistoryCount));
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        var passwordHistoryCount = (systemConfiguration.PasswordHistoryCount) - 1;
    //                        var topPasswordHistoryToConsider = getUserPasswordHistory.OrderByDescending(p => p.PasswordChangedOn).Take(passwordHistoryCount).ToList();

    //                        foreach (var tblSecUserPasswordHistoryDto in topPasswordHistoryToConsider)
    //                        {
    //                            bool isPasswordFromHistory = System.String.CompareOrdinal(Convert.ToString(password).Encrypt(), tblSecUserPasswordHistoryDto.OldPassword) == 0;
    //                            if (isPasswordFromHistory)
    //                            {
    //                                return new ValidationResult(string.Format(ICLComResource.validationCustomPasswordHistoryRule, systemConfiguration.PasswordHistoryCount));
    //                            }
    //                        }

    //                    }
    //                }
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }
    //}
}
