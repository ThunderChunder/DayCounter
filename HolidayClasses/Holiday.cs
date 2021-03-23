namespace Test.HolidayClasses
{
    public class Holiday
    {
        protected int Day { get; set; }
        protected int Month { get; set; }

        public Holiday(int day, int month)
        {
            Day = day;
            Month = month;
        }
        public Holiday(int month)
        {
            Month = month;
        }

        public virtual System.DateTime GetDateTimeForYear(int year)
        {
            return new System.DateTime(year, Month, Day);
        }

        public virtual System.DayOfWeek GetDayOfWeek(int year)
        {
            return GetDateTimeForYear(year).DayOfWeek;
        }
    }
}