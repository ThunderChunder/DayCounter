using System;
using Test.Processor;
using Test.HolidayClasses;
using System.Collections.Generic;
using Test.HolidayCollection;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WeekDays();
            BusinessDays();

            //var result = ((((dtEnd - dtStart).TotalDays * 5) - (dtStart.DayOfWeek - dtEnd.DayOfWeek) * 2) / 7) - 1; ##FOUND THIS SOLUTION ONLINE THOUGHT IT BE NICE TO NOTE THERES A BETTER WAY THAN WHAT I THOUGHT OF
        }
        public static void WeekDays()
        {
            try
            {
                BusinessDayCounter busDayCounter = new BusinessDayCounter();

                DateTime dtStart = new DateTime(2013, 10, 7);
                DateTime dtEnd = new DateTime(2013, 10, 9);

                Console.WriteLine(busDayCounter.WeekdaysBetweenTwoDate(dtStart, dtEnd));

                dtStart = new DateTime(2013, 10, 5);
                dtEnd = new DateTime(2013, 10, 14);

                Console.WriteLine(busDayCounter.WeekdaysBetweenTwoDate(dtStart, dtEnd));

                dtStart = new DateTime(2013, 10, 7);
                dtEnd = new DateTime(2014, 1, 1);

                Console.WriteLine(busDayCounter.WeekdaysBetweenTwoDate(dtStart, dtEnd));

                dtStart = new DateTime(2013, 10, 7);
                dtEnd = new DateTime(2013, 10, 5);

                Console.WriteLine(busDayCounter.WeekdaysBetweenTwoDate(dtStart, dtEnd));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void BusinessDays()
        {
            var pHolidays = new PublicHolidays();
            pHolidays.AddHoliday(25, 12, DateEnum.HolidayEnum.ReocurringSameDate);
            pHolidays.AddHoliday(26, 12, DateEnum.HolidayEnum.ReocurringSameDate);
            pHolidays.AddHoliday(1, 1, DateEnum.HolidayEnum.ReocurringSameDate);

            BusinessDayCounter busDayCounter = new BusinessDayCounter();

            DateTime dtStart = new DateTime(2013, 10, 7);
            DateTime dtEnd = new DateTime(2013, 10, 9);
            Console.WriteLine(busDayCounter.BusinessDaysBetweenTwoDates(dtStart, dtEnd, pHolidays));

            dtStart = new DateTime(2013, 12, 24);
            dtEnd = new DateTime(2013, 12, 27);
            Console.WriteLine(busDayCounter.BusinessDaysBetweenTwoDates(dtStart, dtEnd, pHolidays));

            dtStart = new DateTime(2013, 10, 7);
            dtEnd = new DateTime(2014, 1, 1);
            Console.WriteLine(busDayCounter.BusinessDaysBetweenTwoDates(dtStart, dtEnd, pHolidays));
        }
    }
}
