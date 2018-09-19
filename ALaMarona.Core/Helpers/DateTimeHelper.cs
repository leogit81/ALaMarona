using System;

namespace ALaMarona.Core.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime ParseDate(string fecha)
        {
            DateTime f;
            TryParseToUniversalDate(fecha, out f);
            return f;
        }

        public static DateTime? ParseDateNullable(string fecha)
        {
            DateTime f;
            if (TryParseToUniversalDate(fecha, out f))
            {
                return f;
            }
            return new DateTime?();
        }

        public static bool TryParseToUniversalDate(string fecha, out DateTime universalDateTime)
        {
            DateTime dt;
            if (DateTime.TryParse(fecha, out dt))
            {
                universalDateTime = dt.ToUniversalTime();
                return true;
            }
            else
            {
                universalDateTime = new DateTime().ToUniversalTime();
                return false;
            }
        }

        public static string ToLocalTimePreserveTimeZone(this DateTime dateTime)
        {
            return dateTime.ToLocalTime().ToString("O");
        }

        public static string ToLocalTimePreserveTimeZone(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToLocalTimePreserveTimeZone();
            }
            else
            {
                return null;
            }
        }
    }
}
