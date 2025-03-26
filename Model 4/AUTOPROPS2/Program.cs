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
        // "this(name, price, 0)" calls the main constructor and says: "Use the name and price, and set quantity to 0"
    }

    // Default constructor
    public Product() { }

    public string Name
    {
        get { return _name; }
        set
        {
            if (value != null && value.Length > 0)  // Correct check: name cannot be null or empty
            {
                _name = value;
            }
        }
    }

    // GetPrice method - Returns the product's price
    public double GetPrice()
    {
        return _price;
    }

    // GetQuantity method - Returns the quantity of products
    public int GetQuantity()
    {
        return _quantity;
    }

    // TotalValueInStock method - Returns the total value in stock (price * quantity)
    public double TotalValueInStock()
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
        + TotalValueInStock().ToString("F2", CultureInfo.InvariantCulture);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a Product object with name and price, and initial quantity as 0
        Product product = new Product("Cement", 25.90);
        product.Name = "4K SMART TV";

        // Displaying the product details
        Console.WriteLine(product.Name);
        Console.WriteLine();
    }
}
