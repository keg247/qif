using System;
using System.Globalization;

namespace Keg247.Qif
{
    static class Common
    {
        internal static bool GetBoolean(string value)
        {
            bool result;

            if ((bool.TryParse(value, out result) == false) && (value.Length > 0))
            {
                throw new InvalidCastException(Resources.InvalidBooleanFormat);
            }

            return result;

        }

        private static string GetRealDateString(string value)
        {
            // Find the apostrophe
            int i = value.IndexOf("'", StringComparison.Ordinal);

            // If the apostrophe is present
            if (i != -1)
            {
                // Extract everything but the apostrophe
                var sRet = value.Substring(0, i) + "/" + value.Substring(i + 1);

                return sRet.Replace(" ", "0");
            }

            // Otherwise, just return the raw value
            return value;
        }

        internal static decimal GetDecimal(string value)
        {
            decimal result;

            if (decimal.TryParse(value, out result) == false)
            {
                throw new InvalidCastException(Resources.InvalidDecimalFormat);
            }

            return result;
        }

        internal static DateTime GetDateTime(string value)
        {
            // Prepare the return value
            DateTime result;

            // If parsing the date string fails
            var realDateString = GetRealDateString(value);
            if (DateTime.TryParse(realDateString, CultureInfo.CurrentCulture, DateTimeStyles.None, out result) == false)
            {
                // Identify that the value couldn't be formatted
                throw new InvalidCastException(Resources.InvalidDateFormat);
            }

            // Return the date value
            return result;
        }
    }
}
