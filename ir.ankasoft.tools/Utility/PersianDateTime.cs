using ir.ankasoft.resource;
using System;
using System.Globalization;

namespace ir.ankasoft.tools.Utility
{
    public class PersianDateTime
    {
        public static PersianDateFragments Now()
        {
            DateTime now = DateTime.Now;
            return tools.Convert.gregorianDateTimeToFragmentedPersianDateTime(now);
        }

        public static string getDayofWeek(DateTime dateTime)
        {
            Calendar calendar = CultureInfo.InvariantCulture.Calendar;
            switch (calendar.GetDayOfWeek(dateTime))
            {
                case DayOfWeek.Saturday:
                    return Resource.Saterday;

                case DayOfWeek.Sunday:
                    return Resource.Sunday;

                case DayOfWeek.Monday:
                    return Resource.Monday;

                case DayOfWeek.Tuesday:
                    return Resource.Tuesday;

                case DayOfWeek.Wednesday:
                    return Resource.Wednesday;

                case DayOfWeek.Thursday:
                    return Resource.Thursday;

                case DayOfWeek.Friday:
                    return Resource.Friday;

                default:
                    throw new Exception("NotValidDayOfWeek");
            }
        }

        public static string toLongPersianDate()
        {
            throw new NotImplementedException();
        }

        public static string toShortPersianDate()
        {
            throw new NotImplementedException();
        }

        public static string Today { get; set; }
    }
}