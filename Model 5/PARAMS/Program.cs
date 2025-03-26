using System;

class Program
{
    /*The 'params' modifier allows a method to accept a variable number of arguments of the same type, without needing to manually create an array.

        Always used with a type followed by [] (e.g., params int[] numbers).
        It must be the last parameter of the method.
        It allows passing multiple values without needing to create an array.*/
    static void SumNumbers(params int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine($"The sum of the numbers is: {sum}");
    }

    static void Main()
    {
        Console.Write("How many numbers would you like to sum? ");
        int quantity = int.Parse(Console.ReadLine());

        int[] numbersToSum = new int[quantity];

        for (int i = 0; i < quantity; i++)
        {
            Console.Write($"Enter the {i + 1}st number: ");
            numbersToSum[i] = int.Parse(Console.ReadLine());
        }

        SumNumbers(numbersToSum);
    }
}
