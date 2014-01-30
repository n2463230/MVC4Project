using System;
using System.Text.RegularExpressions;

namespace FundingPilotSystem.BLL.Common
{
    public static class ValidateBusinessLogic
    {
        public static bool CheckNullOrEmpty<T>(T value)
        {            
            bool returnValue = true;

            if (typeof(T) == typeof(string))
                returnValue = !string.IsNullOrEmpty(value as string);
            if (typeof(T) == typeof(byte[]))
                returnValue = value != null;
            if (typeof(T) == typeof(DateTime))
                returnValue = Convert.ToDateTime(value) != null;
            if ((typeof(T) == typeof(int)) || (typeof(T) == typeof(Int16)) || (typeof(T) == typeof(Int32)) || (typeof(T) == typeof(Int64)))
                returnValue = (value != null ? (Convert.ToString(value).Length > 0) : false);
            
            //returnValue = (value == null || value.Equals(default(T)));

            return returnValue;
        }

        public static bool IsValidEmail(string strIn)
        {
            string email = strIn;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }




    }
}
