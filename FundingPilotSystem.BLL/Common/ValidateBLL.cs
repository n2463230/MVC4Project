using System;
using System.Text.RegularExpressions;

namespace FundingPilotSystem.BLL
{

    /// <summary>
    /// This class contains basic validations for business layer
    /// </summary>
    public static class ValidateBLL
    {

        /// <summary>
        /// Checks for null or empty for any provided data types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Validates email address
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
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
