using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    public static void Main(string[] args)
    {
        List<Employee> listofEmployee = new List<Employee>();

        Console.Write("Enter the number of employees: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"Enter #{i + 1} data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Hours: ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write("Value Per Hour: ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("OutSourced (y/n) : ");
            char choose = char.Parse(Console.ReadLine());
            choose = char.ToUpper(choose); // deixando maiusculo 
            if (choose == 'Y')
            {
                Console.Write("Enter the Additional Charge: ");
                double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                listofEmployee.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
            }
            else
            {
                listofEmployee.Add(new Employee(name, hours, valuePerHour));
            }
        }
        Console.WriteLine();
        Console.WriteLine("PAYMENTS: ");

        foreach (Employee rumlist in listofEmployee)
        {
            Console.WriteLine($"Name: {rumlist.Name} - $ {rumlist.Payment().ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}

