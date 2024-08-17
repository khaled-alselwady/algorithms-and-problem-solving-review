public class Solution
{
    private static Random _random = new();
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

    public static List<byte> NumberToDigitsInOrder(int number)
    {
        if (number == 0)
        {
            return [];
        }

        return NumberToDigits(ReverseNumber(number));
    }

    public static bool IsPalindrome(int number)
    {
        return number == ReverseNumber(number);
    }

    public static void PrintInvertedNumberPattern(int number)
    {
        for (int i = number; i >= 1; i--)
        {
            for (int j = i; j >= 1; j--)
            {
                Console.Write(i);
            }

            Console.WriteLine();
        }
    }

    public static void PrintNumberPattern(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(i);
            }

            Console.WriteLine();
        }
    }

    public static void PrintInvertedLetterPattern(int number)
    {
        for (int i = 65 + number - 1; i >= 65; i--)
        {
            for (int j = i - 65; j >= 0; j--)
            {
                Console.Write((char)i);
            }

            Console.WriteLine();
        }
    }

    public static void PrintLetterPattern(int number)
    {
        for (int i = 1; i <= number; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write((char)(i + 64));
            }

            Console.WriteLine();
        }
    }

    private static void _Swap(ref int x, ref int y)
    {
        (x, y) = (y, x);
    }

    public static void ShaffleArray(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            int randIndex = _random.Next(0, array.Length);

            _Swap(ref array[i], ref array[randIndex]);
        }
    }

    public static int[] GetDistinctArray(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return [];
        }

        List<int> distinctNumbers = [];

        foreach (int i in array)
        {
            if (!distinctNumbers.Contains(i))
            {
                distinctNumbers.Add(i);
            }
        }

        return distinctNumbers.ToArray();
    }

    public static bool IsPalindrome(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return false;
        }

        for (int i = 0; i <= array.Length / 2; i++)
        {
            if (array[i] != array[array.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
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

        // AllDigitFrequency(1223422331);

        // Console.WriteLine(string.Join(", ", NumberToDigitsInOrder(1234)));

        // Console.WriteLine(IsPalindrome(12521));

        // PrintInvertedNumberPattern(9);
        // PrintNumberPattern(5);

        // PrintInvertedLetterPattern(26);
        // PrintLetterPattern(26);

        int[] numbers = [1, 2, 3, 4, 5, 2, 1, 4];
        //ShaffleArray(numbers);
        //int[] distinctNumbers = GetDistinctArray(numbers);


        // Console.WriteLine(string.Join(", ", distinctNumbers));

        Console.WriteLine(IsPalindrome([1, 2, 3, 5, 2, 1]));
    }
}