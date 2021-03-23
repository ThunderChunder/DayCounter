namespace Test.HolidayClasses
{
    public class WeekDayHoliday : Holiday
    {
        public WeekDayHoliday(int day, int month) : base(day, month)
        {

        }
        public override System.DayOfWeek GetDayOfWeek(int year)
        {
            return GetDateTimeForYear(year).DayOfWeek;
        }

        public override System.DateTime GetDateTimeForYear(int year)
        {
            var date = new System.DateTime(year, Month, Day);
            var daysForward = 0;
            switch (date.DayOfWeek)
            {
                case (System.DayOfWeek.Saturday):
                    daysForward = 2;
                    break;
                case (System.DayOfWeek.Sunday):
                    daysForward = 1;
                    break;
            }

            return date.AddDays(daysForward);
        }
    }
}