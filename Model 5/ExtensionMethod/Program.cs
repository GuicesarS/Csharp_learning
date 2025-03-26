using System;
using System.Globalization;

static class DatetimeExtension
{
    public static string ElapsedTime(this DateTime thiObj)
    {
        TimeSpan duration = DateTime.Now.Subtract(thiObj);
        if (duration.TotalHours < 24.0)
        {
            return duration.TotalHours.ToString("F1", CultureInfo.InvariantCulture) + "Hours";
        }
        else
        {
            return duration.TotalDays.ToString("F1", CultureInfo.InvariantCulture) + "Days";
        }
    }
}
class Program
{
    public static void Main(string[] args)
    {
        DateTime dt = new DateTime(2018, 11, 16, 8, 10, 45);
        Console.WriteLine(dt.ElapsedTime());
    }
}