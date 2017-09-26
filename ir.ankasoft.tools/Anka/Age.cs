using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ir.ankasoft.tools.Anka
{
    public struct Age : IFormattable, IComparable, IComparable<Age>, IComparable<TimeSpan>
    {
        public static readonly Age Empty = new Age(DateTime.MinValue, DateTime.MinValue);

        #region Private Variables

        private DateTime _advent;
        private DateTime _terminus;
        private int _years;
        private int _months;
        private int _weeks;
        private int _days;

        #endregion Private Variables

        #region Constructors

        /// <summary>
        /// Creates a new instance of Age starting from the given date until now
        /// </summary>
        /// <param name="advent"></param>
        public Age(DateTime advent)
            : this(advent, getNowFromKind(advent))
        {
        }

        /// <summary>
        /// Creates a new instance of Age starting from the given date until now
        /// </summary>
        /// <param name="advent"></param>
        /// <param name="terminus"></param>
        public Age(DateTime advent, DateTime terminus)
        {
            _advent = advent;
            _terminus = terminus;

            _years = 0;
            _months = 0;
            _weeks = 0;
            _days = 0;

            updateInternal();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the number of years old
        /// </summary>
        public int Years
        {
            get { return _years; }
        }

        /// <summary>
        /// Gets the number of months old
        /// </summary>
        public int Months
        {
            get { return _months; }
        }

        /// <summary>
        /// Gets the number of weeks old
        /// </summary>
        public int Weeks
        {
            get { return _weeks; }
        }

        /// <summary>
        /// Gets the number of days old
        /// </summary>
        public int Days
        {
            get { return _days; }
        }

        /// <summary>
        /// Gets/Sets the start of the age
        /// </summary>
        public DateTime Advent
        {
            get { return _advent; }
            set
            {
                _advent = value;
                updateInternal();
            }
        }

        /// <summary>
        /// Gets/Sets the end of the age
        /// </summary>
        public DateTime Terminus
        {
            get { return _terminus; }
            set
            {
                _terminus = value;
                updateInternal();
            }
        }

        /// <summary>
        /// Gets the elapsed time
        /// </summary>
        public TimeSpan Elapsed
        {
            get { return new TimeSpan(_terminus.Ticks - _advent.Ticks); }
        }

        /// <summary>
        /// Gets a value indicating that the age is empty (both advent and terminus dates are MinValue)
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty
        {
            get
            {
                return _advent == DateTime.MinValue
                    && _terminus == DateTime.MinValue;
            }
        }

        #endregion Properties

        #region Update

        /// <summary>
        /// Updates the age to now
        /// </summary>
        public Age Update()
        {
            return Update(getNowFromKind(_advent));
        }

        /// <summary>
        /// Updates the age to the given terminus
        /// </summary>
        /// <param name="terminus"></param>
        public Age Update(DateTime terminus)
        {
            return new Age(_advent, terminus);
        }

        /// <summary>
        /// Updates the values for years, months, weeks and days
        /// </summary>
        private void updateInternal()
        {
            Extract(_advent, _terminus, out _years, out _months, out _weeks, out _days);
        }

        #endregion Update

        #region Extract

        /// <summary>
        /// Calculates the years, months, weeks and days within the two given dates
        /// </summary>
        /// <remarks>
        /// Implementation based on http://tommycarlier.blogspot.com/2006/02/years-months-and-days-between-2-dates.html#links
        /// </remarks>
        /// <param name="advent"></param>
        /// <param name="terminus"></param>
        /// <param name="years"></param>
        /// <param name="months"></param>
        /// <param name="weeks"></param>
        /// <param name="days"></param>
        public static void Extract(DateTime advent, DateTime terminus, out int years, out int months, out int weeks, out int days)
        {
            /// only extracts down to 'days', so the TimeOfDay needs to be
            /// normalised for this calculation
            TimeSpan time = advent.TimeOfDay;
            if (time > TimeSpan.Zero)
            {
                advent = advent.Subtract(time);
                terminus = terminus.Subtract(time);
            }

            years = terminus.Year - advent.Year;
            months = terminus.Month - advent.Month;
            days = terminus.Day - advent.Day;
            weeks = 0;

            if (days < 0) months -= 1;
            while (months < 0)
            {
                months += 12;
                years -= 1;
            }

            TimeSpan span = terminus - advent.AddYears(years).AddMonths(months);
            days = (int)Math.Floor(span.TotalDays);

            if (days > 0)
            {
                weeks = days / 7;
                days = days % 7;
            }
        }

        #endregion Extract

        #region ToString

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(0, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="significantPlaces"></param>
        /// <returns></returns>
        public string ToString(int significantPlaces)
        {
            return ToString(significantPlaces, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="significantPlaces"></param>
        /// <param name="includeTime"></param>
        /// <returns></returns>
        public string ToString(int significantPlaces, bool includeTime)
        {
            if (IsEmpty)
            {
                return string.Empty;
            }

            int max = significantPlaces < 1 ? 10 : significantPlaces;
            int parts = 0;

            StringBuilder result = new StringBuilder();
            if (_years > 0 && parts < max)
            {
                //result.AppendFormat(" {0} سال{1}", _years, plural(_years));
                result.AppendFormat(" {0} سال", _years);
                ++parts;
            }
            if (_months > 0 && parts < max)
            {
                //result.AppendFormat(" {0} ماه{1}", _months, plural(_months));
                result.AppendFormat(" {0} ماه", _months);
                ++parts;
            }
            if (_weeks > 0 && parts < max)
            {
                //result.AppendFormat(" {0} هفته{1}", _weeks, plural(_weeks));
                result.AppendFormat(" {0} هفته", _weeks);
                ++parts;
            }
            if (_days > 0 && parts < max)
            {
                //result.AppendFormat(" {0} روز{1}", _days, plural(_days));
                result.AppendFormat(" {0} روز", _days);
                ++parts;
            }

            if (includeTime)
            {
                TimeSpan time = Elapsed;
                if (time.Hours != 0 && parts < max)
                {
                    //result.AppendFormat(" {0} ساعت{1}", time.Hours, plural(time.Hours));
                    result.AppendFormat(" {0} ساعت", time.Hours);
                    ++parts;
                }
                if (time.Minutes != 0 && parts < max)
                {
                    //result.AppendFormat(" {0} دقیقه{1}", time.Minutes, plural(time.Minutes));
                    result.AppendFormat(" {0} دقیقه", time.Minutes);
                    ++parts;
                }
                if (time.Seconds != 0 && parts < max)
                {
                    //result.AppendFormat(" {0} ثانیه{1}", time.Seconds, plural(time.Seconds));
                    result.AppendFormat(" {0} ثانبه", time.Seconds);
                    ++parts;
                }
            }

            return result.Length == 0
                //? includeTime ? "less than a second" : "less than a day"
                ? includeTime ? "کمتر از یک ثانبه" : "کمتر از یک روز"
                : result.ToString().Trim();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {
            return ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }

        #region IFormattable Members

        /// <summary>
        ///
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            /// TODO: Finish implmenting the provider
            if (string.IsNullOrEmpty(format)) format = "g";

            char first = format[0];
            if (char.ToLower(first) == 'g')
            {
                int parts = 0;
                if (format.Length > 1 && char.IsDigit(format[1]))
                    parts = int.Parse(format[1].ToString());
                return ToString(parts);
            }
            else if (char.IsDigit(first))
            {
                int parts = int.Parse(first.ToString());
                return ToString(parts);
            }

            throw new FormatException("Could not parse the Age format: " + format);
        }

        #endregion IFormattable Members

        #endregion ToString

        #region getNowFromKind

        /// <summary>
        /// Gets the current date/time for universal vrs local time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private static DateTime getNowFromKind(DateTime time)
        {
            return time.Kind == DateTimeKind.Utc ? DateTime.UtcNow : DateTime.Now;
        }

        #endregion getNowFromKind

        #region plural

        /// <summary>
        /// Returns a "s" for numbers other than 0 otherwise an empty string.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string ظlural(int number)
        {
            return number == 1 ? string.Empty : "s";
        }

        #endregion plural

        #region Format

        /// <summary>
        ///
        /// </summary>
        /// <param name="advent"></param>
        /// <returns></returns>
        public static string Format(DateTime advent)
        {
            return Format(advent, getNowFromKind(advent), 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="advent"></param>
        /// <param name="terminus"></param>
        /// <returns></returns>
        public static string Format(DateTime advent, DateTime terminus)
        {
            return Format(advent, terminus, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="advent"></param>
        /// <param name="parts"></param>
        /// <returns></returns>
        public static string Format(DateTime advent, int parts)
        {
            return Format(advent, getNowFromKind(advent), parts);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="advent"></param>
        /// <param name="terminus"></param>
        /// <param name="parts"></param>
        /// <returns></returns>
        public static string Format(DateTime advent, DateTime terminus, int parts)
        {
            return new Age(advent, terminus).ToString(parts);
        }

        #endregion Format

        #region IComparable Members

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj is Age)
            {
                return CompareTo((Age)obj);
            }
            else if (obj is TimeSpan)
            {
                return CompareTo((TimeSpan)obj);
            }

            throw new ArgumentException(string.Format("The object '{0}' is of the wrong type for comparison.", obj.GetType(), "obj"));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Age other)
        {
            return CompareTo(other.Elapsed);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TimeSpan other)
        {
            return Elapsed.CompareTo(other);
        }

        #endregion IComparable Members

        #region GetHashCode (Commented Out)

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public override int GetHashCode()
        //{
        //    return _advent.GetHashCode() ^ _terminus.GetHashCode();
        //}

        #endregion GetHashCode (Commented Out)

        #region Equals (Commented Out)

        ///// <summary>
        ///// Tests weather the object is of an equal age by comparing their elapsed timespans.
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public override bool Equals( object obj )
        //{
        //    if( obj is Age )
        //    {
        //        return this == (Age)obj;
        //    }
        //    else if( obj is TimeSpan )
        //    {
        //        return this.Elapsed == (TimeSpan)obj;
        //    }
        //    return false;
        //}

        #endregion Equals (Commented Out)

        #region Operators

        #region "==" and "!=" (Commented Out)

        ///// <summary>
        /////
        ///// </summary>
        ///// <remarks>
        ///// There is some controversy on overriding the Equals operator.
        ///// </remarks>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <returns></returns>
        //public static bool operator ==( Age x, Age y )
        //{
        //    if( (object)x == null ) return (object)y == null;
        //    return x.Elapsed == y.Elapsed;
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <returns></returns>
        //public static bool operator !=( Age x, Age y )
        //{
        //    return !( x == y );
        //}

        #endregion "==" and "!=" (Commented Out)

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >(Age x, Age y)
        {
            if ((object)y == null) return (object)x != null;
            return x.Elapsed > y.Elapsed;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <(Age x, Age y)
        {
            if ((object)x == null) return (object)y != null;
            return x.Elapsed < y.Elapsed;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >=(Age x, Age y)
        {
            if ((object)y == null) return (object)x != null;
            return x.Elapsed >= y.Elapsed;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <=(Age x, Age y)
        {
            if ((object)x == null) return (object)y != null;
            return x.Elapsed <= y.Elapsed;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static implicit operator TimeSpan(Age age)
        {
            return age.Elapsed;
        }

        #endregion Operators
    }
}
