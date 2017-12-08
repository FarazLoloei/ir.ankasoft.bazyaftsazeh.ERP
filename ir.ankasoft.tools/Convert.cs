using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ir.ankasoft.tools
{
    public class Convert
    {
        public static PersianDateFragments gregorianDateTimeToFragmentedPersianDateTime(string dateTime)
        {
            return gregorianDateTimeToFragmentedPersianDateTime(DateTime.Parse(dateTime));
        }

        public static PersianDateFragments gregorianDateTimeToFragmentedPersianDateTime(DateTime dateTime)
        {
            System.Globalization.PersianCalendar persianCalender = new System.Globalization.PersianCalendar();

            return new PersianDateFragments()
            {
                Year = persianCalender.GetYear(dateTime),
                Month = System.Convert.ToByte(persianCalender.GetMonth(dateTime)),
                Day = System.Convert.ToByte(persianCalender.GetDayOfMonth(dateTime)),
                Hour = System.Convert.ToByte(persianCalender.GetHour(dateTime)),
                Minute = System.Convert.ToByte(dateTime.Minute),
                Second = System.Convert.ToByte(dateTime.Second)
            };
        }

        public static DateTime persianDateToGregorianDate(DateTime persianDate)
        {
            return System.Convert.ToDateTime(persianDateToGregorianDate(persianDate.ToShortDateString()));
        }

        public static DateTime persianDateToGregorianDate(string persianDate)
        {
            if (string.IsNullOrEmpty(persianDate)) return DateTime.MinValue;// string.Empty;
            DateTime Date = DateTime.Parse(persianDateToGregorianDateTimeString(persianDate));

            return System.Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                Date.Year.ToString(),
                Date.Month.ToString("d2"),
                Date.Day.ToString("d2")));
        }

        private static string persianDateToGregorianDateTimeString(string persianDateTime)
        {
            PersianDateFragments dateFragments = ExtractDateTimeFromString(persianDateTime);
            System.Globalization.PersianCalendar persianCalander = new System.Globalization.PersianCalendar();
            try
            {
                DateTime GregorianDate = persianCalander.ToDateTime(
                    dateFragments.Year,
                    dateFragments.Month,
                    dateFragments.Day,
                    dateFragments.Hour,
                    dateFragments.Minute,
                    0,
                    0,
                    0);
                return String.Format("{0:M/d/yyyy}", GregorianDate) + " " + GregorianDate.ToLongTimeString();
            }
            catch
            {
                throw new Exception("InvalidDateTimeFormat");
            }
        }

        private static PersianDateFragments ExtractDateTimeFromString(string DateTime)
        {
            PersianDateFragments Result = new PersianDateFragments();
            string RegexExp = @"((?<Year>[12][0-9][0-9][0-9])[-/\\](?<Month>[0-1][0-9])[-/\\](?<Day>[0-3][0-9])\s(?<Hour>[0-2][0-9])[:](?<Minute>[0-5][0-9]))|" +
                              @"((?<Hour>[0-2][0-9])[:](?<Minute>[0-5][0-9])\s(?<Year>[12][0-9][0-9][0-9])[-/\\](?<Month>[0-1][0-9])[-/\\](?<Day>[0-3][0-9]))|" +
                              @"((?<Year>[12][0-9][0-9][0-9])[-/\\](?<Month>[0-1][0-9])[-/\\](?<Day>[0-3][0-9]))";
            Regex RegularExpression = new Regex(RegexExp);
            MatchCollection Matches = RegularExpression.Matches(DateTime);

            if (Matches.Count == 0)
            {
                throw new Exception("InvalidDateTimeFormat");
            }

            foreach (Match Match in Matches)
            {
                string FullFunctionName = Match.Groups["FullFuctionName"].ToString();
                Result.Year = int.Parse(Match.Groups["Year"].ToString());
                Result.Month = byte.Parse(Match.Groups["Month"].ToString());
                Result.Day = byte.Parse(Match.Groups["Day"].ToString());
                byte hour = 0;
                byte.TryParse(Match.Groups["Hour"].ToString(), out hour);
                Result.Hour = hour;
                byte minute = 0;
                byte.TryParse(Match.Groups["Minute"].ToString(), out minute);
                Result.Minute = minute;
                break;
            }
            return Result;
        }

        public static string GroupDigiting(double value)
        {
            return GroupDigiting(value, 0);
        }

        public static string GroupDigiting(double value, int precision)
        {
            return value.ToString(string.Format("N{0}", precision), CultureInfo.InvariantCulture);
        }


        public static string GroupDigiting(string value, int precision)
        {
            return System.Convert.ToDouble(value).ToString(string.Format("N{0}", precision), CultureInfo.InvariantCulture);
        }
    }
}