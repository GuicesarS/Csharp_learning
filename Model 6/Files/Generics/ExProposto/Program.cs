using System;
using System.Collections.Generic;

class Students
{
    public int Id { get; set; }

    public Students(int id)
    {
        Id = id;
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        if (!(obj is Students))
        {
            return false;
        }
        Students other = obj as Students;
        return Id.Equals(other.Id);
    }
}

class Program
{
    static void Main(string[] args)
    {
        HashSet<int> courseA = new HashSet<int>();
        HashSet<int> courseB = new HashSet<int>();
        HashSet<int> courseC = new HashSet<int>();

        Console.Write("How many students in course A: ");
        int quantity = int.Parse(Console.ReadLine());
        for (int i = 0; i < quantity; i++)
        {
            int code = int.Parse(Console.ReadLine());
            courseA.Add(code);
        }

        Console.Write("How many students in course B: ");
        int quantityB = int.Parse(Console.ReadLine());
        for (int i = 0; i < quantityB; i++)
        {
            int code = int.Parse(Console.ReadLine());
            courseB.Add(code);
        }

        Console.Write("How many students in course C: ");
        int quantityC = int.Parse(Console.ReadLine());
        for (int i = 0; i < quantityC; i++)
        {
            int code = int.Parse(Console.ReadLine());
            courseC.Add(code);
        }

        HashSet<int> totalStudents = new HashSet<int>(courseA);
        totalStudents.UnionWith(courseB);
        totalStudents.UnionWith(courseC);

        Console.Write($"Total students: {totalStudents.Count}");
    }
}
