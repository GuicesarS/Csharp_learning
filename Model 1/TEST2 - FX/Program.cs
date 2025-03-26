using System;
using System.Globalization;
namespace Employee{
    public class Employee
    {
        public string name;
        public double salary;
        
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            {

                Employee one,two;
                one = new Employee();
                two = new Employee();

                Console.WriteLine("Enter the name of first employee:");
                one.name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter the salary of first employee:");
                one.salary = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Enter the name of second employee:");
                two.name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter the age of second employee:");
                two.salary = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                

                double salary_average = (one.salary+two.salary)/2;
                Console.WriteLine($"The salary average is: {salary_average}");
            }
        }
    }
}