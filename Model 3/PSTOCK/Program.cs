using System;
using System.Globalization;

public class Product
{
    public string Name;
    public double Price;
    public int Quantity;

    public void AddProduct(int quantity)
    {
        Quantity += quantity;
    }

    public void RemoveProduct(int quantity)
    {
        Quantity -= quantity;
    }
    public double TotalValueInStock()
    {
        return Price * Quantity;
    }
    public override string ToString()
    {
        return $"Product: {Name}, Price: {Price.ToString("F2", CultureInfo.InvariantCulture)},{Quantity} units, Quantity in Stock: {TotalValueInStock().ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

public class Program
{
    public static void Main(string[] agrs)
    {
        Product p1 = new Product();

        Console.WriteLine("Enter the name of product:");
        p1.Name = Console.ReadLine();

        Console.WriteLine($"Enter the price of {p1.Name}:");
        p1.Price = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine($"How many {p1.Name} we have:");
        p1.Quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(p1);
        Console.WriteLine(" ");

        Console.WriteLine($"Enter the quantity of {p1.Name} you will add:");
        int add = Convert.ToInt32(Console.ReadLine());
        p1.AddProduct(add);
        Console.WriteLine($"Updated data: {p1}");
        Console.WriteLine(" ");

        Console.WriteLine($"Enter the quantity of {p1.Name} you will remove:");
        int remove = Convert.ToInt32(Console.ReadLine());
        p1.RemoveProduct(remove);
        Console.WriteLine($"Updated data: {p1}");
    }

}