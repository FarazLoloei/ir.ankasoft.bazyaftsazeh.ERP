using ir.ankasoft.resource;
using ir.ankasoft.tools.Enum;
using System;

namespace ir.ankasoft.tools
{
    public class PersianDateFragments
    {
        public int Year { get; set; }
        public byte Month { get; set; }
        public byte Day { get; set; }

        public byte Hour { get; set; }
        public byte Minute { get; set; }
        public byte Second { get; set; }

        public override string ToString()
        {
            //PersianDateFragments persianDateFragments = Utility.PersianDateTime.Now();
            return string.Format("{0}/{1}/{2} {3}:{4}:{5} {6}",
                Year,
                Month,
                Day,
                Hour,
                Minute,
                Second,
                Hour > 12 ? enumClockType.PM : enumClockType.AM
                );
        }

        public string ToShortDateString()
        {
            //PersianDateFragments persianDateFragments = Utility.PersianDateTime.Now();
            //return string.Format("{0}/{1}/{2}",
            //    persianDateFragments.Year,
            //    persianDateFragments.Month.ToString("D2"),
            //    persianDateFragments.Day.ToString("D2")
            //    );
            return string.Format("{0}/{1}/{2}",
               Year,
               Month.ToString("D2"),
               Day.ToString("D2")
               );
        }

        public string MonthOfYear
        {
            get
            {
                enumPersianMonthName monthName = (enumPersianMonthName)Month - 1;
                switch (monthName)
                {
                    case enumPersianMonthName.Farvardin:
                        return Resource.Farvardin;

                    case enumPersianMonthName.Ordibehesht:
                        return Resource.Ordibehesht;

                    case enumPersianMonthName.Khordad:
                        return Resource.Khordad;

                    case enumPersianMonthName.Tir:
                        return Resource.Tir;

                    case enumPersianMonthName.Mordad:
                        return Resource.Mordad;

                    case enumPersianMonthName.Shahrivar:
                        return Resource.Shahrivar;

                    case enumPersianMonthName.Mehr:
                        return Resource.Mehr;

                    case enumPersianMonthName.Aban:
                        return Resource.Aban;

                    case enumPersianMonthName.Azar:
                        return Resource.Azar;

                    case enumPersianMonthName.Dey:
                        return Resource.Dey;

                    case enumPersianMonthName.Bahman:
                        return Resource.Bahman;

                    case enumPersianMonthName.Esfand:
                        return Resource.Esfand;

                    default:
                        throw new Exception("InvalidMonthName");
                }
            }
        }
    }
}