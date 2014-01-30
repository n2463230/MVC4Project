using FundingPilotSystem.Domain.SolutionUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FundingPilotSystem.Domain.SolutionUtilities
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


}
