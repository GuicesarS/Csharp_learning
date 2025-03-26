using System;
using System.Collections.Generic;
using System.Globalization;

// Enum that defines the worker's levels
enum WorkerLevel : int
{
    Junior = 0,
    MidLevel = 1,
    Senior = 2
}

// Class that represents the department where the worker works
class Department
{
    public string Name { get; set; }

    public Department() { } // Default constructor

    public Department(string name) // Constructor that takes the department's name
    {
        Name = name;
    }
}

// Class that represents an hourly work contract
class HourContract
{
    public DateTime Date { get; set; } // Date of the contract
    public double ValuePerHour { get; set; } // Amount paid per worked hour
    public int Hours { get; set; } // Number of hours worked

    public HourContract() { } // Default constructor

    public HourContract(DateTime date, double valuePerHour, int hours) // Constructor that initializes the values
    {
        Date = date;
        ValuePerHour = valuePerHour;
        Hours = hours;
    }

    public double TotalValue() // Method that calculates the total value of the contract
    {
        return ValuePerHour * Hours;
    }
}

// Class that represents a worker
class Worker
{
    public string Name { get; set; } // Worker’s name
    public WorkerLevel Level { get; set; } // Worker’s experience level (Junior, MidLevel, Senior)
    public double BaseSalary { get; set; } // Worker’s base monthly salary
    public Department Department { get; set; } // Worker’s department
    public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // List of the worker's contracts

    public Worker() { } // Default constructor

    // Constructor that initializes the worker's data
    public Worker(string name, WorkerLevel level, double baseSalary, Department department)
    {
        Name = name;
        Level = level;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddContract(HourContract contract) // Method to add a contract to the list
    {
        Contracts.Add(contract);
    }

    public void RemoveContract(HourContract contract) // Method to remove a contract from the list
    {
        Contracts.Remove(contract);
    }

    // Method to calculate the worker's income in a specific month/year
    public double Income(int year, int month)
    {
        double income = BaseSalary; // Starts with the base salary

        // Loops through the contracts list and adds the contracts that belong to the given month/year
        foreach (var contract in Contracts)
        {
            if (contract.Date.Year == year && contract.Date.Month == month)
            {
                income += contract.TotalValue();
            }
        }
        return income; // Returns the worker's total income for the specified period
    }
}

// Main class with the Main method
class Program
{
    static void Main()
    {
        // Captures the department's name
        Console.Write("Enter department's name: ");
        string departmentName = Console.ReadLine();

        // Captures the worker's data
        Console.WriteLine("Enter Worker data:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); // Converts the string to enum
        Console.Write("Base Salary: ");
        double baseSalary = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture); // Reads the worker's base salary

        // Creates a new department and worker
        Department dept = new Department(departmentName);
        Worker worker = new Worker(name, level, baseSalary, dept);

        // Captures the number of contracts for the worker
        Console.Write("How many contracts for this worker: ");
        int n = int.Parse(Console.ReadLine());

        // Loop to add the contracts to the worker
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Contract #{i}:");
            Console.Write("Date (dd/mm/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine()); // Reads the contract date
            Console.Write("Value per hour: ");
            double valuePerHour = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture); // Reads the value per hour
            Console.Write("Hours: ");
            int hours = int.Parse(Console.ReadLine()); // Reads the number of hours for the contract

            // Creates a contract and adds it to the worker
            HourContract contract = new HourContract(date, valuePerHour, hours);
            worker.AddContract(contract);
        }

        Console.WriteLine();
        Console.WriteLine($"Input month and year (MM/YYYY) of Employee {worker.Name} to calculate income:");
        string monthAndYear = Console.ReadLine();

        // Extracts month and year from the string provided by the user
        int month = int.Parse(monthAndYear.Substring(0, 2));
        int year = int.Parse(monthAndYear.Substring(3));

        // Displays the total salary of the worker for the specified month/year
        Console.WriteLine($"Employee {worker.Name} received a total income of R$ {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
    }
}
