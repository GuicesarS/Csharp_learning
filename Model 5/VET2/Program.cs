using System;
using System.Globalization;

class Program
{
    public static void Main(string[] args)
    {
        int products = int.Parse(Console.ReadLine());
        string[] productArray = new string[products]; // array to store the products.
        double[] productValueArray = new double[products]; // array to store the value.

        for (int i = 0; i < products; i++)
        {
            Console.Write($"Enter the name of product {i + 1}: ");
            productArray[i] = Console.ReadLine();
            Console.Write($"Value of {productArray[i]}: ");
            productValueArray[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
        Console.WriteLine("\nData collected!");
        for (int i = 0; i < products; i++) // display them on the screen
        {
            Console.WriteLine($"Product: {productArray[i]} - Value: {productValueArray[i].ToString("F2", CultureInfo.InvariantCulture)}");
        }

        double sum = 0;
        for (int i = 0; i < products; i++)
        {
            sum += productValueArray[i];
        }
        double average = sum / products;
        Console.WriteLine($"Average value of products: {average.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}
