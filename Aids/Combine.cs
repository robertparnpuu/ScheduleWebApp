using System;

namespace Aids
{
    public static class Combine
    {
        public static DateTime DateAndTime(DateTime date, DateTime time) => 
            new(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

    }
}
