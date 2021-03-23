using Test.HolidayClasses;
using System.Collections.Generic;
using Test.DateEnum;

namespace Test.HolidayCollection
{
    public class PublicHolidays
    {
        private List<Holiday> Holidays { get; set; }

        public PublicHolidays()
        {
            Holidays = new List<Holiday>();
        }

        public void AddHoliday(int day, int month, HolidayEnum holidayType, System.DayOfWeek dayOfWeek = System.DayOfWeek.Monday)
        {
            switch (holidayType)
            {
                case (HolidayEnum.ReocurringSameDate):
                    Holidays.Add(new SameDateHoliday(day, month));
                    break;
                case (HolidayEnum.ReocurringWeekDayOnlyDate):
                    Holidays.Add(new WeekDayHoliday(day, month));
                    break;
                case (HolidayEnum.ReocurringSameDay):
                    Holidays.Add(new ExactDayOccuranceHoliday(day, month, dayOfWeek));//day here is day occurance!
                    break;
            }
        }
        public IEnumerable<Holiday> GetHolidays()
        {
            return Holidays;
        }
    }
}