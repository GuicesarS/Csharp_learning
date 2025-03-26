using System;
using System.Globalization;

class Product
{
    // Private attributes (encapsulation)
    private string _name;
    private double _price;
    private int _quantity;

    public Product(string name, double price, int quantity)
    {
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    // Constructor with 2 parameters (calls the main constructor with 3 parameters and sets quantity as 0)
    public Product(string name, double price) : this(name, price, 0)
    {
        // "this(name, price, 0)" calls the main constructor and says: "Use the name and price, and set quantity as 0"
    }

    public Product() { }

    // GetQuantity method - Returns the quantity of products
    public int GetQuantity()
    {
        return _quantity;
    }

    public double TotalValueInStock()
    {
        return _price * _quantity;
    }

    public void AddProducts(int quantity)
    {
        _quantity += quantity;
    }

    public void RemoveProducts(int quantity)
    {
        _quantity -= quantity;
    }

    public override string ToString()
    {
        return _name
        + ", $ "
        + _price.ToString("F2", CultureInfo.InvariantCulture)
        + ", "
        + _quantity
        + " units, Total: $ "
        + TotalValueInStock().ToString("F2", CultureInfo.InvariantCulture);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a Product object with name and price, and initial quantity as 0
        Product product = new Product("Cement", 25.90);

        // Displaying the product data
        Console.WriteLine(product);
        Console.WriteLine();

        // Asking the user the quantity to be added
        Console.WriteLine($"Enter the quantity of {product.GetQuantity()} you want to add:");
        int addQuantity = int.Parse(Console.ReadLine());
        product.AddProducts(addQuantity);  // Adding to stock
        Console.WriteLine();
        Console.WriteLine("Updated data: " + product);
        Console.WriteLine();

        // Asking the user the quantity to be removed
        Console.WriteLine($"Enter the quantity of {product.GetQuantity()} you want to remove:");
        int removeQuantity = int.Parse(Console.ReadLine());
        product.RemoveProducts(removeQuantity);  // Removing from stock
        Console.WriteLine("Updated data: " + product);
        Console.WriteLine();

        // Checking if the stock is empty
        if (product.GetQuantity() == 0)
        {
            Console.WriteLine($"All stock of {product.GetQuantity()} has been sold! Please wait for the next restock.");
        }
    }
}
