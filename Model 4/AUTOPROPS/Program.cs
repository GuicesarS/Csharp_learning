using System;
using System.Globalization;

class Product
{
    // Private attributes (encapsulation)
    private string _name;
    private double _price;
    private int _quantity;

    // Constructor with 3 parameters
    public Product(string name, double price, int quantity)
    {
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    // Constructor with 2 parameters (calls the main constructor with 3 parameters and sets quantity to 0)
    public Product(string name, double price) : this(name, price, 0)
    {
        // The "this(name, price, 0)" calls the main constructor and says: "Use the name and price, and set quantity to 0"
    }

    // Default constructor
    public Product() { }

    // GetName method - Returns the name of the product
    public string GetName()
    {
        return _name;
    }

    // SetName method - Sets the product's name but validates that the name is not null or empty
    public void SetName(string name)
    {
        if (name != null && name.Length > 0)  // Correct check: name cannot be null and cannot be empty
        {
            _name = name;
        }
    }

    // GetPrice method - Returns the price of the product
    public double GetPrice()
    {
        return _price;
    }

    // GetQuantity method - Returns the quantity of products
    public int GetQuantity()
    {
        return _quantity;
    }

    // TotalStockValue method - Returns the total value in stock (price * quantity)
    public double TotalStockValue()
    {
        return _price * _quantity;
    }

    // AddProducts method - Adds a quantity to the stock
    public void AddProducts(int quantity)
    {
        _quantity += quantity;
    }

    // RemoveProducts method - Removes a quantity from the stock
    public void RemoveProducts(int quantity)
    {
        _quantity -= quantity;
    }

    // ToString method - Returns a string with all the product details
    public override string ToString()
    {
        return _name
        + ", $ "
        + _price.ToString("F2", CultureInfo.InvariantCulture)
        + ", "
        + _quantity
        + " units, Total: $ "
        + TotalStockValue().ToString("F2", CultureInfo.InvariantCulture);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a Product object with name and price, and initial quantity as 0
        Product product = new Product("Cement", 25.90);

        // Displaying product data
        Console.WriteLine(product);
        Console.WriteLine();

        // Asking the user how many units they want to add
        Console.WriteLine($"Enter the quantity of {product.GetQuantity()} you want to add:");
        int addQuantity = int.Parse(Console.ReadLine());
        product.AddProducts(addQuantity);  // Adding to the stock
        Console.WriteLine();
        Console.WriteLine("Updated data: " + product);
        Console.WriteLine();

        // Asking the user how many units they want to remove
        Console.WriteLine($"Enter the quantity of {product.GetQuantity()} you want to remove:");
        int removeQuantity = int.Parse(Console.ReadLine());
        product.RemoveProducts(removeQuantity);  // Removing from the stock
        Console.WriteLine("Updated data: " + product);
        Console.WriteLine();

        // Checking if the stock is empty
        if (product.GetQuantity() == 0)
        {
            Console.WriteLine($"All stock of {product.GetQuantity()} has been sold! Please wait for the next restocking.");
        }
    }
}
