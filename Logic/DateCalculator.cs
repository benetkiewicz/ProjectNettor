namespace Logic
{
    using System;

    public class DateCalculator
    {
        public DateTime CalculateEndTime(DateTime now)
        {
            int minutes = RunDown(now.Minute);
            if (minutes < 60)
            {
                return new DateTime(now.Year, now.Month, now.Day, now.Hour, minutes, 0);
            }

            return new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0).AddHours(1);
        }

        private static int RunDown(int minutes)
        {
            if (minutes < 0)
            {
                throw new ArgumentOutOfRangeException("minutes", "Minute can not be negative.");
            }

            if (minutes < 8)
            {
                return 0;
            }

            if (minutes < 23)
            {
                return 15;
            }

            if (minutes < 38)
            {
                return 30;
            }

            if (minutes < 53)
            {
                return 45;
            }

            return 60;
        }
    }
}