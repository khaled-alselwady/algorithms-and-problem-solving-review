public class Solution
{
    public static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        if (number == 2 || number == 3)
        {
            return true;
        }

        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        //double sqrtNumber = Math.Sqrt(number);

        //for (int i = 5; i <= sqrtNumber; i += 6)
        //{
        //    if ((number % i == 0) || (number % (i + 2) == 0))
        //    {
        //        return false;
        //    }
        //}

        for (int i = 5; i * i <= number; i += 6)
        {
            if ((number % i == 0) || (number % (i + 2) == 0))
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsPerfect(int number)
    {
        if (number <= 0)
        {
            return false;
        }

        int sum = 0;
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }

        return (sum == number);
    }

    public static List<byte> NumberToDigits(int number)
    {
        if (number == 0)
        {
            return [];
        }

        List<byte> result = [];
        while (number > 0)
        {
            int digit = number % 10;
            number /= 10;
            result.Add((byte)digit);
        }

        return result;
    }

    public static int ReverseNumber(int number)
    {
        if (number == 0)
        {
            return 0;
        }

        int reverseNumber = 0;

        while (number > 0)
        {
            int digit = number % 10;
            number /= 10;
            reverseNumber = reverseNumber * 10 + digit;
        }

        return reverseNumber;
    }

    public static byte CountDigitFrequency(int number, int digit)
    {
        if (number == 0)
        {
            return 0;
        }

        List<byte> digits = NumberToDigits(number);

        return (byte)digits.Count(x => x == digit);
    }

    public static void AllDigitFrequency(int number)
    {
        if (number == 0)
        {
            return;
        }

        for (int i = 0; i <= 9; i++)
        {
            int sumCurrentDigit = CountDigitFrequency(number, i);

            if (sumCurrentDigit > 0)
            {
                Console.WriteLine($"Digit {i} Frequency is => {sumCurrentDigit} time(s)");
            }
        }
    }

    private static void Main()
    {
        // Console.WriteLine(IsPrime(29));
        // Console.WriteLine(IsPerfect(28));
        //Console.WriteLine(string.Join(", ", NumberToDigits(1234)));
        //List<byte> digits = NumberToDigits(1234);
        //Console.WriteLine(digits.Sum(x => x));

        // Console.WriteLine(ReverseNumber(1234));

        // Console.WriteLine(CountDigitFrequency(123422, 2));

        AllDigitFrequency(1223422331);
    }
}