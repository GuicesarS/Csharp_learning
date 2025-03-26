using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System;
using Classes;

class Program
{
    public static void Main(string[] args)
    {
        // Console.Write("Enter the file path: ");
        // string filePath = Console.ReadLine();

        string filePath = @"C:\Users\Guilherme.Soares\Desktop\Estudoc#\Reviews\Introduction\Model 6\Linq\EX01Fix\data.txt";
        List<Person> peopleList = new List<Person>();

        try
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] infoArray = sr.ReadLine().Split(",");
                    string name = infoArray[0];
                    string email = infoArray[1];
                    double salary = double.Parse(infoArray[2], CultureInfo.InvariantCulture);
                    peopleList.Add(new Person(name, email, salary));
                }
            }

            Console.Write("Enter the salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var filteredEmails = peopleList.Where(p => p.Salary > baseSalary).Select(p => p.Email);

            var salarySum = peopleList.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);

            Console.WriteLine($"\nPeople with salary greater than R$ {baseSalary}: ");
            foreach (string email in filteredEmails)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine($"\nSum of salaries of people whose name starts with 'M': {salarySum.ToString("F2", CultureInfo.InvariantCulture)}");

        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}
