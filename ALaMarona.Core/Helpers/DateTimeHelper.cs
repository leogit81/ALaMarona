using System;

namespace ALaMarona.Core.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime ParseDate(string fecha)
        {
            DateTime f;
            if (DateTime.TryParse(fecha, out f))
            {
                return f.ToUniversalTime();
            }
            return new DateTime();
        }

        public static string ToLocalTime(this DateTime dateTime)
        {
            return dateTime.ToLocalTime().ToString("O");
        }
    }
}
