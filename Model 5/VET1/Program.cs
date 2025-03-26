using System;
using System.Globalization;

class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        double[] vet = new double[n]; // create the array according to "n";
        for (int i = 0; i < n; i++)
        {
            vet[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }

        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += vet[i];
        }

        double average = sum / n;
        Console.WriteLine($"The average is: {average}");
    }
}
