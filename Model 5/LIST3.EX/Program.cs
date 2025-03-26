using System;
using System.Collections.Generic;
using System.Globalization;

class Product_Model
{
    public int Id { get; set; }
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _name = value;
            }
        }
    }
    public double Price { get; set; }
    
    public Product_Model(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("How many products will be added: ");
        int quantity = int.Parse(Console.ReadLine());

        List<Product_Model> productList = new List<Product_Model>();
        for (int i = 0; i < quantity; i++)
        {
            Console.Write($"Product {i + 1} details");
            Console.Write("\nProduct ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write($"Price of {name} ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            // list.Add + Object instantiation
            productList.Add(new Product_Model(id, name, price));
        }

        int choice;
        do
        {
            Console.WriteLine("\nWill there be a price update?");
            Console.WriteLine("1 - YES");
            Console.WriteLine("2 - NO");
            choice = int.Parse(Console.ReadLine());

            if (choice != 1 && choice != 2)
            {
                Console.WriteLine("Invalid option! Please try again.");
            }
        } while (choice != 1 && choice != 2);

        if (choice == 1)
        {
            Console.WriteLine("Enter the product ID that will have its price adjusted");
            int desiredId = int.Parse(Console.ReadLine());

            Product_Model findId = productList.Find(x => x.Id == desiredId);
            if (findId != null)
            {
                Console.WriteLine("What is the new price of the product?");
                double newPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                findId.UpdatePrice(newPrice);
            }

            Console.WriteLine($"The price of {findId.Name} has been changed!");
            foreach (Product_Model obj in productList)
            {
                Console.WriteLine($"Here are the added products: {obj.Id} -- {obj.Name} -- {obj.Price.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
        else if (choice == 2)
        {
            foreach (Product_Model obj in productList)
            {
                Console.WriteLine($"\nOkay! Here are the added products: {obj.Id} -- {obj.Name} -- {obj.Price.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
        else
        {
            Console.WriteLine("Invalid option");
        }
    }
}
