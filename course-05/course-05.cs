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

    private static void Main()
    {
        Console.WriteLine(IsPrime(29));
    }
}