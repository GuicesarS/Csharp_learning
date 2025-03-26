using System;
using System.Globalization;

// Class that converts currency (dollar to real)
public class CurrencyConverter
{
    // IOF rate (Tax on Financial Transactions) applied during the conversion
    public static double Iof = 6.0;

    // Method to convert dollars to reais
    // It receives the amount in dollars and the current exchange rate
    public static double DollarToReal(double amount, double exchangeRate)
    {
        // Calculate the total value in reais without including the IOF
        double total = amount * exchangeRate;

        // Add the IOF to the total amount and return the result
        return total + total * Iof / 100;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Ask the user for the current exchange rate (how much 1 dollar is worth in reais)
        Console.Write("What is the current exchange rate of the dollar: ");
        // Read the exchange rate input by the user and convert it to a number (with support for decimal point)
        double exchangeRate = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        // Ask the user how many dollars they want to convert to reais
        Console.Write("What is the amount you want to convert: ");
        // Read the amount input by the user and convert it to a number
        double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        // Use the "CurrencyConverter" class to calculate the total value in reais, including the IOF
        // Since it's static, I can access it from anywhere, and it has fixed values, nothing changes for any conversion case.
        double total = CurrencyConverter.DollarToReal(amount, exchangeRate);

        // Display the final result on the screen, formatted to 2 decimal places
        Console.WriteLine($"The total amount is R$ {total.ToString("F2", CultureInfo.InvariantCulture)}");
    }
}
