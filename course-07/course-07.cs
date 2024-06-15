using System.Text;

public static class StringBuilderExtensions
{
    public static string SubstringBuilder(this StringBuilder sb, int startIndex, int length)
    {
        if (sb == null || startIndex < 0 || length < 0 || startIndex + length > sb.Length)
        {
            return string.Empty;
        }

        char[] buffer = new char[length];
        sb.CopyTo(startIndex, buffer, 0, length);
        return new string(buffer);
    }

    public static int IndexOfBuilder(this StringBuilder sb, string value, int startIndex = 0)
    {
        if (sb == null || value == null || value.Length == 0 ||
            startIndex > sb.Length || value.Length > sb.Length)
        {
            return -1;
        }

        for (int i = startIndex; i < sb.Length; i++)
        {
            int j;
            for (j = 0; j < value.Length; j++)
            {
                if (sb[i + j] != value[j])
                {
                    break;
                }
            }

            if (j == value.Length)
            {
                return i;
            }
        }

        return -1;
    }
}

public class Solution
{
    #region Matrix
    private static Random random = new Random();

    public static void FillMatrixWithRandomNumbers(int[,] matrix, int from, int to)
    {
        if (matrix == null)
        {
            return;
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(from, to + 1);
            }
        }
    }

    public static void FillMatrixWithOrderedNumbers(int[,] matrix)
    {
        if (matrix == null)
        {
            return;
        }

        int counter = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = ++counter;
            }
        }
    }

    private static int _SumRowInMatrix(int[,] matrix, int rowIndex)
    {
        if (matrix == null || rowIndex <= -1)
        {
            return 0;
        }

        int columnLength = matrix.GetLength(1);
        int sum = 0;

        for (int i = 0; i < columnLength; i++)
        {
            sum += matrix[rowIndex, i];
        }

        return sum;
    }

    public static void PrintSumRowsInMatrix(int[,] matrix)
    {
        if (matrix == null)
        {
            return;
        }

        int rowLength = matrix.GetLength(0);

        for (int i = 0; i < rowLength; i++)
        {
            Console.WriteLine($"Row {i + 1} Sum = {_SumRowInMatrix(matrix, i)}");
        }
    }

    private static int[]? _SumRowsInMatrixToArray(int[,] matrix)
    {
        if (matrix == null)
        {
            return null;
        }

        int rowLength = matrix.GetLength(0);
        int[] arrSum = new int[rowLength];

        for (int i = 0; i < rowLength; i++)
        {
            arrSum[i] = _SumRowInMatrix(matrix, i);
        }

        return arrSum;
    }

    public static void PrintSumRowsInMatrixFromArray(int[]? arrSum)
    {
        if (arrSum == null)
        {
            return;
        }

        for (int i = 0; i < arrSum.Length; i++)
        {
            Console.WriteLine($"Row {i + 1} Sum = {arrSum[i]}");
        }
    }

    public static void PrintTransposeMatrix(int[,] originalMatrix, int[,] transposeMatrix)
    {
        if (originalMatrix == null || originalMatrix.Length == 0 ||
            transposeMatrix == null)
        {
            return;
        }

        for (int i = 0; i < originalMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < originalMatrix.GetLength(1); j++)
            {
                transposeMatrix[i, j] = originalMatrix[j, i];
            }
        }

    }

    public static void PrintMiddleRowInMatrix(int[,] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return;
        }

        int middleRow = matrix.GetLength(0) / 2;
        int colLength = matrix.GetLength(1);

        Console.WriteLine("Middle Row in Matrix:");
        for (int i = 0; i < colLength; i++)
        {
            Console.Write(matrix[middleRow, i] + "   ");
        }
    }

    public static void PrintMiddleColInMatrix(int[,] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return;
        }

        int rowLength = matrix.GetLength(0);
        int middleCol = matrix.GetLength(1) / 2;

        Console.WriteLine("Middle Col in Matrix:");
        for (int i = 0; i < rowLength; i++)
        {
            Console.Write(matrix[i, middleCol] + "   ");
        }
    }

    public static void Print(int[,] matrix, string message)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return;
        }

        Console.WriteLine(message);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "   ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static bool IsMatrixIdentity(int[,] matrix)
    {
        if (matrix == null)
        {
            return false;
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j && matrix[i, j] != 1)
                {
                    return false;
                }

                else if (i != j && matrix[i, j] != 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool IsMatrixScalar(int[,] matrix)
    {
        if (matrix == null)
        {
            return false;
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j && matrix[i, j] != matrix[0, 0])
                {
                    return false;
                }

                else if (i != j && matrix[i, j] != 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool _IsRowPalindromeInMatrix(int[,] matrix, int rowIndex)
    {
        if (matrix == null || rowIndex <= -1)
        {
            return false;
        }

        int colLength = matrix.GetLength(1);

        for (int i = 0; i <= colLength / 2; i++)
        {
            if (matrix[rowIndex, i] != matrix[rowIndex, colLength - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    public static bool IsMatrixPalindrome(int[,] matrix)
    {
        if (matrix == null)
        {
            return false;
        }

        int rowLength = matrix.GetLength(0);

        for (int i = 0; i < rowLength; i++)
        {
            if (!_IsRowPalindromeInMatrix(matrix, i))
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Fibnoacci Series
    public static void FibonacciSeries(int n)
    {
        int prev2 = 0;
        int prev1 = 1;

        Console.Write(prev2 + "  ");
        Console.Write(prev1 + "  ");

        for (int i = 2; i < n; i++)
        {
            int sum = prev1 + prev2;
            prev2 = prev1;
            prev1 = sum;

            Console.Write(sum + "  ");
        }
    }

    public static void FibonacciSeries(int n, int prev2 = 0, int prev1 = 1)
    {
        Console.Write(prev2 + "  ");

        if (n > 1)
        {
            int sum = prev2 + prev1;
            prev2 = prev1;
            prev1 = sum;

            FibonacciSeries(--n, prev2, prev1);
        }
    }
    #endregion

    #region String
    public enum enCharacterType
    {
        UpperCase = 0,
        LowerCase = 1,
        Numbers = 2,
        SpecialCharacters = 3,
        Spaces = 4
    }

    public static void PrintFirstLetterOfEachWord(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        bool IsFirstLetter = true;

        foreach (char letter in text)
        {
            if (IsFirstLetter && letter != ' ')
            {
                Console.WriteLine(letter);
            }

            IsFirstLetter = (letter == ' ');
        }

    }

    public static string UpperLetterOfEachWord(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        StringBuilder sbUpperLetterOfEachWord = new StringBuilder(text);
        bool IsFirstLetter = true;

        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            if (IsFirstLetter && letter != ' ')
            {
                sbUpperLetterOfEachWord[i] = char.ToUpper(letter);
            }

            IsFirstLetter = (letter == ' ');
        }

        return sbUpperLetterOfEachWord.ToString();
    }

    public static char InvertCharacter(char character)
        => char.IsLower(character) ?
           char.ToUpper(character) : char.ToLower(character);

    public static string InvertAllLettersInText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        StringBuilder sbInvertAllLettersInText = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            sbInvertAllLettersInText.Append(InvertCharacter(text[i]));
        }

        return sbInvertAllLettersInText.ToString();
    }

    private static enCharacterType _GetCharacterType(char character)
    {
        if (char.IsLetter(character))
        {
            if (char.IsLower(character))
            {
                return enCharacterType.LowerCase;
            }
            else
            {
                return enCharacterType.UpperCase;
            }
        }
        else if (char.IsDigit(character))
        {
            return enCharacterType.Numbers;
        }
        else if (character == ' ')
        {
            return enCharacterType.Spaces;
        }
        else
        {
            return enCharacterType.SpecialCharacters;
        }
    }

    public static int CountLetterByType(string text, enCharacterType characterType)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return 0;
        }

        int count = 0;

        foreach (char character in text)
        {
            if (_GetCharacterType(character) == characterType)
            {
                count++;
            }
        }

        return count;
    }

    public static int CountLetterInText(string text, char letterToCount, bool ignoreCase = true)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return 0;
        }

        return ignoreCase ? text.Count(c => char.ToLower(c) == char.ToLower(letterToCount)) :
                            text.Count(c => c == letterToCount);
    }

    public static bool IsVowel(char character)
        => "aeiouAEIOU".Contains(character);

    public static List<string> Split(string text, string separator)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return [];
        }

        List<string> splitWords = new List<string>();
        StringBuilder sbText = new StringBuilder(text);
        int indexOfSeparator = -1;

        while ((indexOfSeparator = sbText.IndexOfBuilder(separator)) != -1)
        {
            string word = sbText.SubstringBuilder(0, indexOfSeparator);

            splitWords.Add(word);

            sbText.Remove(0, (indexOfSeparator + separator.Length));
        }

        if (sbText.Length > 0)
        {
            splitWords.Add(sbText.ToString());
        }

        return splitWords;
    }

    public static List<string> Split2(string text, string separator)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return [];
        }

        List<string> splitWords = new List<string>();
        StringBuilder sbText = new StringBuilder(text);
        int indexOfSeparator = -1;
        int start = 0;

        while ((indexOfSeparator = sbText.IndexOfBuilder(separator, start)) != -1)
        {
            string word = sbText.SubstringBuilder(start, indexOfSeparator - start);

            splitWords.Add(word);

            start = indexOfSeparator + separator.Length;
        }

        if (start < sbText.Length)
        {
            splitWords.Add(sbText.SubstringBuilder(start, sbText.Length - start));
        }

        return splitWords;
    }

    public static string TrimLeft(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ')
            {
                return text.Substring(i, text.Length - i);
            }
        }

        return string.Empty;
    }

    public static string TrimRight(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        for (int i = text.Length - 1; i >= 0; i--)
        {
            if (text[i] != ' ')
            {
                return text.Substring(0, i + 1);
            }
        }

        return string.Empty;
    }

    public static string Trim(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        return TrimLeft(TrimRight(text));
    }

    public static string Join(List<string> words, string separator)
    {
        if (words == null || words.Count == 0 || separator == null || separator == "")
        {
            return string.Empty;
        }

        StringBuilder wordsJoin = new StringBuilder();

        foreach (string word in words)
        {
            wordsJoin.Append($"{word}{separator}");
        }

        return (wordsJoin.Remove(wordsJoin.Length - separator.Length, separator.Length)).ToString();
    }

    public static string Join(string[] words, string separator)
    {
        if (words == null || words.Length == 0 || separator == null || separator == "")
        {
            return string.Empty;
        }

        StringBuilder wordsJoin = new StringBuilder();

        foreach (string word in words)
        {
            wordsJoin.Append($"{word}{separator}");
        }

        return (wordsJoin.Remove(wordsJoin.Length - separator.Length, separator.Length)).ToString();
    }

    public static string Reverse(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        List<string> words = Split(text, " ");

        StringBuilder reverseWords = new StringBuilder();

        for (int i = words.Count - 1; i >= 0; i--)
        {
            reverseWords.Append($"{words[i]} ");
        }

        return reverseWords.Remove(reverseWords.Length - 1, 1).ToString();
    }

    public static string Replace(string text, string oldWord, string newWord, bool ignoreCase = false)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        List<string> words = Split(text, " ");

        if (ignoreCase)
        {
            oldWord = oldWord.ToLower();
        }

        for (int i = 0; i < words.Count; i++)
        {
            if (ignoreCase)
            {
                if (words[i].ToLower() == oldWord)
                {
                    words[i] = newWord;
                }
            }
            else
            {
                if (words[i] == oldWord)
                {
                    words[i] = newWord;
                }
            }

        }

        return Join(words, " ");
    }

    public static string RemovePunctuations(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return string.Empty;
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            if (!char.IsPunctuation(text[i]))
            {
                sb.Append(text[i]);
            }
        }

        return sb.ToString();
    }
    #endregion

    static void Main()
    {
        string text = "Khaled Yousef Slimna Ashraf.";

        Console.WriteLine(RemovePunctuations(text));
        Console.ReadKey();
    }
}

