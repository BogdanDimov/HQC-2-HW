using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentException("Can't get subsequence of an empty array!");
        }

        if (startIndex < 0 || startIndex > arr.Length - 1)
        {
            throw new ArgumentException("Start index must be positive and less than arr's length!");
        }

        if (count < 0 || startIndex + count > arr.Length - 1)
        {
            throw new ArgumentException("Count must be positive and startIndex + count must be less than arr's length!");
        }

        var result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentNullException("Can't extract ending of an empty string!");
        }

        if (count > str.Length)
        {
            throw new ArgumentException(String.Format("Invalid count ({0})!", count));
        }

        var result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number <= 1)
        {
            throw new ArgumentOutOfRangeException("Number must be positive and greater than 1!");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                throw new ArgumentException(String.Format("The number {0} is not prime!", number));
            }
        }
    }

    public static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            var number = 23;

            CheckPrime(number);
            Console.WriteLine("{0} is prime.", number);

            number = 33;
            Console.WriteLine("{0} is prime.", number);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        var peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
