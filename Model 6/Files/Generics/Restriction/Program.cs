using System;
using System.Collections.Generic;
using System.Globalization;

class Product : IComparable
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public int CompareTo(object obj)
    {
        if (!(obj is Product))
        {
            throw new ArgumentException("Error: Argument is not of type 'Product'.");
        }

        Product other = obj as Product;
        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"{Name} , {Price.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

class CalculationService
{
    public T Max<T>(List<T> list) where T : IComparable
    {
        if (list.Count == 0)
        {
            throw new ArgumentException("List cannot be empty.");
        }

        T max = list[0];
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CompareTo(max) > 0)
            {
                max = list[i];
            }
        }
        return max;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> list = new List<Product>();

        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] vect = Console.ReadLine().Split(',');
            double price = double.Parse(vect[1], CultureInfo.InvariantCulture);
            list.Add(new Product(vect[0], price));
        }

        CalculationService calculationService = new CalculationService();

        Product p = calculationService.Max(list); // <Product> is optional

        Console.WriteLine("Most expensive:");
        Console.WriteLine(p);
    }
}
