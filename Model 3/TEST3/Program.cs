using System;
using System.Globalization;

// Student class

public class Student
{
    public string Name;
    public double Grade1;
    public double Grade2;
    public double Grade3;

    // Calculate final grade
    public double Final()
    {
        return (Grade1 + Grade2 + Grade3);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student student = new Student();
        Console.Write($"Enter the student's name: ");
        student.Name = Console.ReadLine();
        Console.Write($"Enter the first grade: ");
        student.Grade1 = Convert.ToDouble(Console.ReadLine());
        Console.Write($"Enter the second grade: ");
        student.Grade2 = Convert.ToDouble(Console.ReadLine());
        Console.Write($"Enter the third grade: ");
        student.Grade3 = Convert.ToDouble(Console.ReadLine());

        student.Final();
        if (student.Final() < 60)
        {
            Console.WriteLine($"The student {student.Name} has failed. {60 - student.Final()} points are missing.");
        }
        else
        {
            Console.WriteLine($"The student {student.Name} is approved.");
        }
    }
}
