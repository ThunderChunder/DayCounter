using System.Collections.Generic;
using Test.HolidayCollection;

namespace Test.Processor
{
    public class BusinessDayCounter
    {
        private System.DateTime StartDate { get; set; }
        private System.DateTime EndDate { get; set; }
        private int StartDay { get; set; }
        private int EndDay { get; set; }
        private int TotalDays { get; set; }
        private int TotalWeekends { get; set; }
        private DateEnum.DayEnum Config;

        private int TotalDaysResult
        {
            get
            {
                var result = TotalDays - TotalWeekends;
                if (result < 0) { return 0; }
                return result;
            }
        }
        private void CalcValues(System.DateTime firstDate, System.DateTime secondDate)
        {
            StartDate = firstDate;
            EndDate = secondDate;
            Config = Test.DateEnum.DayEnum.CountNone;
            TotalDays = CalcTotalDays();
            ProcessEnum();
            TotalWeekends = CalcTotalWeekends();
        }
        public int WeekdaysBetweenTwoDate(System.DateTime firstDate, System.DateTime secondDate)
        {
            if (Test.Validator.DateTimeValidator.IsDatesValid(firstDate, secondDate))
            {
                CalcValues(firstDate, secondDate);
                return TotalDaysResult;
            }
            return 0;
        }
        public int BusinessDaysBetweenTwoDates(System.DateTime firstDate, System.DateTime secondDate, PublicHolidays publicHolidays)
        {
            if (Test.Validator.DateTimeValidator.IsDatesValid(firstDate, secondDate))
            {
                CalcValues(firstDate, secondDate);
                ExcludePublicHolidays(publicHolidays);
                return TotalDaysResult;
            }
            return 0;
        }
        private void ExcludePublicHolidays(PublicHolidays publicHolidays)
        {
            var pHolidays = publicHolidays.GetHolidays();
            var yearToCheck = StartDate.Year;
            var iterations = (EndDate.Year - StartDate.Year);
            System.DateTime currentHoliday;
            foreach (var holiday in pHolidays)
            {
                for (int i = 0; i <= iterations; i++)
                {
                    currentHoliday = holiday.GetDateTimeForYear(yearToCheck + i);
                    if (StartDate < currentHoliday && EndDate > currentHoliday)
                    {
                        DecrementTotalDays();
                    }
                }
            }
        }
        private void DecrementTotalDays()
        {
            if (TotalDays > 0)
            {
                TotalDays--;
            }
        }
        private int CalcTotalDays()
        {
            var roundedValue = System.Math.Floor((EndDate - StartDate).TotalDays);
            return System.Convert.ToInt32(roundedValue);//calculate total days
        }
        private int CalcTotalWeekends()
        {
            if (TotalDays % 7 != 0)
            {
                return ((TotalDays / 7) * 2) + CalcWeekendBetweenDays();
            }
            return (TotalDays / 7) * 2;
        }
        private int CalcWeekendBetweenDays()
        {
            int weekendCounter = 0;
            System.DateTime tempStartDay = StartDate.AddDays(StartDay);
            System.DateTime tempEndDay = EndDate.AddDays(EndDay);
            while (tempStartDay.DayOfWeek != tempEndDay.DayOfWeek)
            {
                if (tempStartDay.DayOfWeek == System.DayOfWeek.Saturday || tempStartDay.DayOfWeek == System.DayOfWeek.Sunday)
                {
                    weekendCounter++;
                }
                tempStartDay = tempStartDay.AddDays(1);
            }
            return weekendCounter;
        }

        private void ProcessEnum()
        {
            switch (Config)
            {
                case (Test.DateEnum.DayEnum.CountStartDay)://Add start day as extra day
                    TotalDays++;
                    StartDay = 0;
                    EndDay = 0;
                    break;
                case (Test.DateEnum.DayEnum.CountEndDay)://Currently already considers end date as a day
                    StartDay = 0;
                    EndDay = 1;
                    break;
                case (Test.DateEnum.DayEnum.CountBoth)://Add start date as extra day
                    TotalDays++;
                    StartDay = 0;
                    EndDay = 1;
                    break;
                case (Test.DateEnum.DayEnum.CountNone)://Disregard end date as a day
                    TotalDays--;
                    StartDay = 1;
                    EndDay = 0;
                    break;
            }
        }
    }
}