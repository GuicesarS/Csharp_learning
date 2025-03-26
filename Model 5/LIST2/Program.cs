using System;
using System.Collections.Generic;
using System.Globalization;

class Employee // Test the word Template first, it might help
{
    public int Id { get; set; }
    public double Salary { get; set; }
    private string _name;

    public string Name
    {
        get { return _name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) // "! - Different from True" if it is not null or just spaces " ".
            {
                _name = value;
            }
        }
    }

    public Employee(int id, double salary, string name)
    {
        Id = id;
        Salary = salary;
        Name = name;
    }

    public void IncreaseSalary(double amount)
    {
        Salary += amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("How many employees will be registered: ");
        int numEmployees = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        List<Employee> employeeList = new List<Employee>();
        for (int i = 0; i < numEmployees; i++)
        {
            Console.Write($"Employee {i + 1}: ");
            Console.Write($"ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write($"Name: ");
            string name = Console.ReadLine();

            Console.Write($"Salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            employeeList.Add(new Employee(id, salary, name)); // employeeList.Add() + new Employee(id, salary, name)

            // new Employee(id, salary, name) = Create a new object based on the Employee class template - ID, SALARY, NAME
            // employeeList.Add() = Add to the list
        }

        Console.WriteLine("Enter the ID of the employee to be promoted: ");
        int promotedId = int.Parse(Console.ReadLine());

        Employee foundEmployee = employeeList.Find(x => x.Id == promotedId);
        if (foundEmployee == null)
        {
            Console.WriteLine("\nError! No employee found with that ID.");
        }
        else
        {
            /* x represents each employee in the list.
            x.Id == promotedId checks if the employee's ID matches the entered promotedId.
            The first employee that meets this condition will be returned.*/    
            bool validValue;

            do
            {
                Console.WriteLine($"Enter the raise amount for {foundEmployee.Name}: ");
                double salaryIncrease = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                validValue = true;

                if (salaryIncrease <= 0)
                {
                    Console.WriteLine("\nError updating the salary! Amount must not be null.");
                    validValue = false;
                }
                else
                {
                    foundEmployee.IncreaseSalary(salaryIncrease);
                    Console.WriteLine("\nSalary Updated!");
                }
            } while (!validValue);
            
            foreach (Employee emp in employeeList)
            {
                Console.WriteLine($"ID: {emp.Id} Name: {emp.Name} Salary: {emp.Salary.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}
