namespace Test.HolidayClasses
{
    public class ExactDayOccuranceHoliday : Holiday
    {
        protected int DayOccurence { get; set; }
        protected System.DayOfWeek DayOfWeek { get; set; }
        public ExactDayOccuranceHoliday(int dayOccurence, int month, System.DayOfWeek day) : base(month)
        {
            if (dayOccurence < 1 || dayOccurence > 4)
            {
                throw new System.ArgumentException(message: "Invalid day occurance.", paramName: nameof(dayOccurence));
            }
            DayOccurence = dayOccurence - 1;
            DayOfWeek = day;
        }

        public override System.DayOfWeek GetDayOfWeek(int year)
        {
            return GetDateTimeForYear(year).DayOfWeek;
        }

        public override System.DateTime GetDateTimeForYear(int year)
        {
            var date = new System.DateTime(year, Month, 1);
            while (date.DayOfWeek != DayOfWeek)
            {
                date = date.AddDays(1);
            }

            return date.AddDays(DayOccurence * 7); 
        }

    }
}