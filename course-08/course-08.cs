using System.Globalization;

public class Solution
{
    private static bool _IsRemainderZero(int num, int divisionBy)
        => (num % divisionBy) == 0;

    public static string NumberToWords(int num)
    {
        if (num == 0)
        {
            return "Zero";
        }

        if (num >= 1 && num <= 19)
        {
            string[] arr = { "", "One", "Two", "Three", "Four", "Five",
                            "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve",
                            "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                            "Eighteen", "Nineteen" };

            return arr[num];
        }

        if (num >= 20 && num <= 99)
        {
            string[] arr = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty",
                            "Seventy", "Eighty", "Ninety" };

            return $"{arr[num / 10]} {(_IsRemainderZero(num, 10) ? string.Empty : NumberToWords(num % 10))}".Trim();
        }

        if (num >= 100 && num <= 999)
        {
            return $"{NumberToWords(num / 100)} Hundred {(_IsRemainderZero(num, 100) ? string.Empty : NumberToWords(num % 100))}".Trim();
        }

        if (num >= 1000 && num <= 999999)
        {
            return $"{NumberToWords(num / 1000)} Thousand {(_IsRemainderZero(num, 1000) ? string.Empty : NumberToWords(num % 1000))}".Trim();
        }

        if (num >= 1000000 && num <= 999999999)
        {
            return $"{NumberToWords(num / 1000000)} Million {(_IsRemainderZero(num, 1000000) ? string.Empty : NumberToWords(num % 1000000))}".Trim();
        }

        if (num >= 1000000000)
        {
            return $"{NumberToWords(num / 1000000000)} Billion {(_IsRemainderZero(num, 1000000000) ? string.Empty : NumberToWords(num % 1000000000))}".Trim();
        }

        return string.Empty;
    }

    public static bool IsLeapYear(short year)
      => (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

    public static bool IsLeapYearUsingBuiltIn(short year)
      => DateTime.IsLeapYear(year);

    public static short DaysInYear(short year)
      => IsLeapYear(year) ? (short)366 : (short)365;
    public static int HoursInYear(short year)
      => DaysInYear(year) * 24;
    public static int MinutesInYear(short year)
      => HoursInYear(year) * 60;
    public static int SecondsInYear(short year)
      => MinutesInYear(year) * 60;

    public static byte DaysInMonth(short year, byte month)
    {
        if (month < 1 || month > 12)
        {
            return 0;
        }

        byte[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        return (month == 2) ? (byte)(IsLeapYear(year) ? 29 : 28) : (daysInMonth[month]);
    }
    public static byte DaysInMonthUsingBuiltIn(short year, byte month)
       => (byte)DateTime.DaysInMonth(year, month);

    public static int HoursInMonth(short year, byte month)
      => DaysInMonth(year, month) * 24;
    public static int MinutesInMonth(short year, byte month)
        => HoursInMonth(year, month) * 60;
    public static int SecondsInMonth(short year, byte month)
        => MinutesInMonth(year, month) * 60;

    public static byte DayOfWeekOrder(short year, byte month, byte day)
    {
        short a, y, m;
        a = (short)((14 - month) / 12);
        y = (short)(year - a);
        m = (short)(month + (12 * a) - 2);
        // Gregorian://0:sun, 1:Mon, 2:Tue...etc
        return (byte)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);
    }
    public static byte DayOfWeekOrderUsingBuiltIn(short year, byte month, byte day)
        => (byte)new DateTime(year, month, day).DayOfWeek;

    public static byte DayOfWeekOrder(DateTime date)
       => DayOfWeekOrder((short)date.Year, (byte)date.Month, (byte)date.Day);

    public static byte DayOfWeekOrderUsingBuiltIn(DateTime date)
        => (byte)date.DayOfWeek;

    public static string DayShortName(byte dayOfWeekOrder)
    {
        string[] arrDayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        return arrDayNames[dayOfWeekOrder];
    }
    public static string DayShortNameUsingBuiltIn(byte dayOfWeekOrder)
    {
        DayOfWeek dayOfWeek = (DayOfWeek)dayOfWeekOrder;
        return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(dayOfWeek);
    }

    public static short TotalDaysFromTheBeginningOfYear(short year, byte month, byte day)
    {
        short totalDays = 0;

        for (byte i = 1; i < month; i++)
        {
            totalDays += DaysInMonthUsingBuiltIn(year, i);
        }

        return (short)(totalDays + day);
    }
    public static short TotalDaysFromTheBeginningOfYearUsingBuiltIn(short year, byte month, byte day)
        => (short)new DateTime(year, month, day).DayOfYear;

    public static DateTime GetDateFromTotalDaysOfTheBeginningOfYear(short totalDays, short year)
    {
        byte month = 1;
        // days in the first month is 31
        byte daysInCurrentMonth = 31;
        short remainingDays = totalDays;
        while (remainingDays > 0 && (remainingDays - daysInCurrentMonth) > 0)
        {
            daysInCurrentMonth = DaysInMonthUsingBuiltIn(year, month);
            month++;
            remainingDays -= daysInCurrentMonth;
        }

        return new DateTime(year, month, remainingDays);
    }
    public static DateTime GetDateFromTotalDaysOfTheBeginningOfYearUsingBuiltIn(short totalDays, short year)
        => new DateTime(year, 1, 1).AddDays(totalDays - 1); // we minus one from the totalDays because we add 1 day in the constructor

    public static DateTime AddDays(DateTime date, int daysToAdd)
    {
        int remainingDays = daysToAdd + TotalDaysFromTheBeginningOfYearUsingBuiltIn((short)date.Year, (byte)date.Month, (byte)date.Day);
        byte day = (byte)date.Day;
        byte month = 1;
        short year = (short)date.Year;

        while (true)
        {
            byte daysInMonth = DaysInMonthUsingBuiltIn(year, month);

            if (remainingDays > daysInMonth)
            {
                remainingDays -= daysInMonth;
                month++;

                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }
            else
            {
                day = (byte)remainingDays;
                break;
            }
        }

        return new DateTime(year, month, day);
    }
    public static DateTime AddDaysUsingBuiltIn(DateTime date, int daysToAdd)
        => date.AddDays(daysToAdd);

    public static bool IsDate1BeforeDate2(DateTime date1, DateTime date2)
    {
        return (date1.Year < date2.Year) ?
                (true) : (date1.Year > date2.Year ?
                (false) : (date1.Month < date2.Month ?
                (true) : (date1.Month > date2.Month ?
                (false) : (date1.Day < date2.Day))));
    }

    public static bool IsDate1EqualDate2(DateTime date1, DateTime date2)
    {
        return (date1.Year != date2.Year) ?
               (false) : (date1.Month != date2.Month ?
               (false) : (date1.Day == date2.Day));
    }

    public static bool IsDate1AfterDate2(DateTime date1, DateTime date2)
    {
        return (date1.Year > date2.Year) ?
               (true) : (date1.Year < date2.Year ?
               (false) : (date1.Month > date2.Month ?
               (true) : (date1.Month < date2.Month ?
               (false) : (date1.Day > date2.Day))));
    }

    public static bool IsLastMonthInYear(byte month)
        => month == 12;
    public static bool IsFirstMonthInYear(byte month)
        => month == 1;

    public static bool IsLastDayInMonth(short year, byte month, byte day)
        => day == DaysInMonthUsingBuiltIn(year, month);
    public static bool IsFirstDayInMonth(byte day)
        => day == 1;

    public static DateTime AddOneDayToDate(DateTime date)
    {
        byte day = (byte)date.Day;
        byte month = (byte)date.Month;
        short year = (short)date.Year;

        if (IsLastDayInMonth((short)date.Year, (byte)date.Month, (byte)date.Day))
        {
            day = 1;

            if (IsLastMonthInYear((byte)date.Month))
            {
                month = 1;
                year = (short)(date.Year + 1);
            }
            else
            {
                month = (byte)(date.Month + 1);
            }
        }
        else
        {
            day = (byte)(date.Day + 1);
        }

        return new DateTime(year, month, day);
    }
    public static DateTime SubtractOneDayFromDate(DateTime date)
    {
        byte day = (byte)date.Day;
        byte month = (byte)date.Month;
        short year = (short)date.Year;

        if (IsFirstDayInMonth(day))
        {
            if (IsFirstMonthInYear(month))
            {
                year--;
                month = 12;
                day = 31;
            }
            else
            {
                month--;
                day = DaysInMonth(year, month);
            }
        }
        else
        {
            day--;
        }

        return new DateTime(year, month, day);
    }

    public static int DiffInDays(DateTime date1, DateTime date2, bool includeEndDay = false)
    {
        int diff = 0;
        sbyte swapFlagValue = 1;

        if (IsDate1AfterDate2(date1, date2))
        {
            (date1, date2) = (date2, date1);
            swapFlagValue = -1;
        }

        while (IsDate1BeforeDate2(date1, date2))
        {
            date1 = AddOneDayToDate(date1);
            diff++;
        }

        return includeEndDay ? (++diff * swapFlagValue) : (diff * swapFlagValue);
    }
    public static int DiffInDaysUsingBuiltIn(DateTime date1, DateTime date2, bool includeEndDay = false)
    {
        int diff = (date2 - date1).Days;
        return includeEndDay ? ++diff : diff;
    }
    public static int AgeInDays(DateTime date)
    {
        return DiffInDays(date, DateTime.Now);
    }

    public static bool IsEndOfWeek(DateTime date)
       => (date.DayOfWeek == DayOfWeek.Saturday);

    public static bool IsWeekend(DateTime date)
       => (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday);

    public static bool IsBusinessDay(DateTime date)
       => !IsWeekend(date);

    public static byte DaysUntilTheEndOfWeek(DateTime date)
       => (byte)((byte)DayOfWeek.Saturday - (byte)date.DayOfWeek);

    public static byte DaysUntilTheEndOfMonth(DateTime date)
       => (byte)(DateTime.DaysInMonth(date.Year, date.Month) - date.Day + 1);

    public static short DaysUntilTheEndOfYear(DateTime date)
       => (short)(DaysInYear((short)date.Year) - date.DayOfYear + 1);

    public static short CalculateActualVacationDays(DateTime startDate, DateTime endDate)
    {
        short vacationDays = 0;

        while (IsDate1BeforeDate2(startDate, endDate))
        {
            if (IsBusinessDay(startDate))
            {
                vacationDays++;
            }

            startDate = AddOneDayToDate(startDate);
        }

        return vacationDays;
    }

    public static DateTime GetVacationDate(DateTime startVacationDate, short actualVacationDays)
    {
        DateTime endVacationDate = startVacationDate;

        while (actualVacationDays > 0)
        {
            if (IsBusinessDay(endVacationDate))
            {
                actualVacationDays--;
            }

            endVacationDate = AddOneDayToDate(endVacationDate);
        }

        return endVacationDate;
    }

    public enum enDateCompare
    {
        Before = -1,
        Equal = 0,
        After = 1
    }

    public static enDateCompare CompareDates(DateTime start, DateTime end)
    {
        if (IsDate1BeforeDate2(start, end))
        {
            return enDateCompare.Before;
        }
        else if (IsDate1AfterDate2(start, end))
        {
            return enDateCompare.After;
        }
        else
        {
            return enDateCompare.Equal;
        }
    }

    public struct stPeriod
    {
        public DateTime Start;
        public DateTime End;
    }

    public static bool IsOverlapPeriods(stPeriod period1, stPeriod period2)
    {
        if (CompareDates(period1.Start, period2.End) == enDateCompare.After ||
            CompareDates(period1.End, period2.Start) == enDateCompare.Before)
        {
            return false;
        }

        return true;
    }

    public static int GetPeriodLength(stPeriod period, bool includeEndDay = false)
        => DiffInDays(period.Start, period.End, includeEndDay);


    private static void Main()
    {
        stPeriod period1 = new stPeriod();
        period1.Start = new DateTime(2022, 2, 1);
        period1.End = new DateTime(2022, 2, 10);

        Console.WriteLine(GetPeriodLength(period1));
        Console.WriteLine(GetPeriodLength(period1, true));

        Console.ReadKey();
    }
}