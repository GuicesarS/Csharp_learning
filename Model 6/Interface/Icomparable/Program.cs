using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

class Employee : IComparable
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public Employee(string csvEmployee)
    {
        string[] vect = csvEmployee.Split(',');
        Name = vect[0];
        Salary = double.Parse(vect[1], CultureInfo.InvariantCulture);
    }

    public override string ToString()
    {
        return Name + " , " + Salary.ToString("F2", CultureInfo.InvariantCulture);
    }

    public int CompareTo(object obj)
    {
        if (!(obj is Employee))
        {
            throw new ArgumentException("Comparison Error: Argument is not of type Employee");
        }
        Employee otherEmployee = obj as Employee;
        return Name.CompareTo(otherEmployee.Name);
        // return Salary.CompareTo(otherEmployee.Salary);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\Guilherme.Soares\Desktop\StudyC#\NewCreatedFile.txt";

        try
        {
            using (StreamReader sr = File.OpenText(path))
            {
                List<Employee> lines = new List<Employee>();
                while (!sr.EndOfStream)
                {
                    lines.Add(new Employee(sr.ReadLine()));
                }
                lines.Sort(); // sort the list
                foreach (Employee line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
