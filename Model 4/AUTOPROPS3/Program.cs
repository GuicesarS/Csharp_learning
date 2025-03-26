using System;
using System.Globalization;

class Product
{
    private string _name; // does not use auto properties because it has unique logic
    public double Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, double price, int quantity)
    {
        _name = name;
        Price = price;
        Quantity = quantity;
    }

    public Product(string name, double price) : this(name, price, 0)
    {
        // The "this(name, price, 0)" calls the main constructor and says: "Use the name and price, and set quantity as 0"
    }

    public Product() { }

    public string Name
    {
        get { return _name; }
        set
        {
            if (value != null && value.Length > 0)  // Correct check: name cannot be null and cannot be empty
            {
                _name = value;
            }
        }
    }

    public double TotalValueInStock()
    {
        return Price * Quantity;
    }

    public void AddProducts(int quantity)
    {
        Quantity += quantity;
    }

    public void RemoveProducts(int quantity)
    {
        Quantity -= quantity;
    }

    public override string ToString()
    {
        return _name
        + ", $ "
        + Price.ToString("F2", CultureInfo.InvariantCulture)
        + ", "
        + Quantity
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
        Console.WriteLine(product.Name);
        Console.WriteLine();
        Console.WriteLine(product.Price.ToString("F2", CultureInfo.InvariantCulture));
    }
}
