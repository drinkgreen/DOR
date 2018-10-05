using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DORv3.HelperLib
{
    public static class DateHelper
    {
        public static int WorkingDaysInMonth(DateTime date)
        {
            return WorkingDaysInMonthUntilDate(LastDayOfTheMonth(date));
        }

        public static int WorkingDaysInMonthUntilDate(DateTime date)
        {
            int dayOfWeek, counter = 0;
            for (dayOfWeek = 1; dayOfWeek <= date.Day; dayOfWeek++)
            {
                counter += (new DateTime(date.Year, date.Month, dayOfWeek).DayOfWeek != DayOfWeek.Sunday) ? 1 : 0;
            }
            return counter;
        }

        public static DateTime FirstDayOfTheMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime LastDayOfTheMonth(DateTime date)
        {
            return new DateTime(date.Year, date.AddMonths(1).Month, 1).AddDays(-1);
        }

        public static List<DateTime> GetAllDatesOfSpecifiedDayOfWeekInMonth(DateTime date, DayOfWeek dow)
        {
            int year = date.Year;
            int month = date.Month;

            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                .Where(d => new DateTime(year, month, d).DayOfWeek == dow)
                .Select(day => new DateTime(year, month, day))
                .ToList();
        }
    }
}
