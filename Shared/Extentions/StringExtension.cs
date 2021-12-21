using System;

namespace Shared.Extentions
{
    public static class StringExtension
    {
        public static double ToDouble(this string value)
        {
            double result;
            double.TryParse(value, out result);
            return result;
        }

        public static TimeSpan ToTimeSpan(this string value)
        {
            TimeSpan result;
            TimeSpan.TryParse(value, out result);
            return result;
        }

        public static int ToInt(this string value)
        {
            int result;
            int.TryParse(value, out result);
            return result;
        }

        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool IsNotNullOrEmpty(this string value) => !string.IsNullOrEmpty(value);

    }
}
