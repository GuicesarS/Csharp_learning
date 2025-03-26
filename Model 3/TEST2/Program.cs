using System;
using System.Globalization;

public class Employee
{
    public string Name;
    public double GrossSalary;
    public double Tax;

    // Method to calculate the net salary
    public double NetSalary()
    {
        return GrossSalary - Tax;
    }

    // Method to increase the salary by a percentage
    public void IncreaseSalary(double percentage)
    {
        GrossSalary += GrossSalary * (percentage / 100);
    }

    public override string ToString()
    {
        return $"Employee: {Name}\n" +
               $"Gross Salary: $ {GrossSalary.ToString("F2", CultureInfo.InvariantCulture)}\n" +
               $"Net Salary: $ {NetSalary().ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Employee person1 = new Employee();

        Console.WriteLine("Enter the employee's name:");
        person1.Name = Console.ReadLine();

        Console.WriteLine($"\nEnter the Gross Salary of {person1.Name}:");
        person1.GrossSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine($"\nEnter the Tax that {person1.Name} pays:");
        person1.Tax = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine("\nEmployee details:");
        Console.WriteLine(person1);

        Console.WriteLine($"\nWould you like to increase {person1.Name}'s salary?");
        Console.WriteLine("YES - Enter the percentage (e.g., 10)");
        Console.WriteLine("NO - Enter 0");

        double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        // Apply the increase if necessary
        if (percentage > 0)
        {
            person1.IncreaseSalary(percentage);
        }

        // Display updated employee details
        Console.WriteLine("\nEmployee details AFTER ADJUSTMENT:");
        Console.WriteLine(person1);
    }
}
