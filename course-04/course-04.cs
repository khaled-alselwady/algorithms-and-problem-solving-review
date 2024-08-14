public class Solution
{

    public static int Factorial(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        int factorial = 1;

        for (int i = n; i > 0; i--)
        {
            factorial *= i;
        }

        return factorial;
    }

    public static float GetDaysCount(int numberOfHours)
    {
        if (numberOfHours == 0)
        {
            return 0;
        }

        return numberOfHours / (float)24;
    }

    public static float GetWeeksCount(int numberOfHours)
    {
        if (numberOfHours == 0)
        {
            return 0;
        }

        return GetDaysCount(numberOfHours) / 7;
    }

    public static int MinutesToSeconds(int minutes)
    {
        return (minutes * 60);
    }

    public static int HoursToMinutes(int hours)
    {
        return (hours * 60);
    }

    public static int DaysToHours(int days)
    {
        return (days * 24);
    }

    public static int HoursToSeconds(int hours)
    {
        return MinutesToSeconds(HoursToMinutes(hours));
    }

    public static int DaysToSeconds(int days)
    {
        return HoursToSeconds(DaysToHours(days));
    }

    public static int GetTotalSeconds(int days, int hours, int minutes, int seconds)
    {
        return DaysToSeconds(days) + HoursToSeconds(hours) + MinutesToSeconds(minutes) + seconds;
    }

    public static int SecondsToDays(int totalSeconds, out int remainder)
    {
        int secondsPerDay = 24 * 60 * 60;

        int days = totalSeconds / secondsPerDay;
        remainder = totalSeconds % secondsPerDay;

        return days;
    }

    public static int SecondsToHours(int totalSeconds, out int remainder)
    {
        int secondsPerHour = 60 * 60;

        int hours = totalSeconds / secondsPerHour;
        remainder = totalSeconds % secondsPerHour;

        return hours;
    }

    public static int SecondsToMinutes(int totalSeconds, out int remainder)
    {
        int secondsPerMinute = 60;

        int minutes = totalSeconds / secondsPerMinute;
        remainder = totalSeconds % secondsPerMinute;

        return minutes;
    }

    public static string GetTimeDuration(int totalSeconds)
    {
        int days = SecondsToDays(totalSeconds, out int dayRemainder);
        int hours = SecondsToHours(dayRemainder, out int hourRemainder);
        int minutes = SecondsToMinutes(hourRemainder, out int seconds);

        return $"{days:D2}:{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    private static void Main()
    {
        // Console.WriteLine(Factorial(6));
        // Console.WriteLine(GetWeeksCount(365).ToString("N2"));
        // Console.WriteLine(GetDaysCount(365).ToString("N2"));

        // Console.WriteLine(GetTotalSeconds(2, 5, 45, 35).ToString("N0"));

        Console.WriteLine(GetTimeDuration(193535));
    }
}