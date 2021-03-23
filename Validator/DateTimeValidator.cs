namespace Test.Validator
{
    public class DateTimeValidator
    {
        public static bool IsDatesValid(System.DateTime start, System.DateTime end)
        {
            try
            {
                return start < end;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }

}