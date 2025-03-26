using System;
using System.Globalization;

public class Product
{
    public string Name;
    public double Price;
    public int Quantity;

    public Product(string name, double price, int quantity) // Forces the user to specify how the object will behave to avoid having a 
    // product without price, name, or quantity. This helps because, if the user does not provide these details, the program may throw an error.
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public Product(string name, double price) // Optional constructor
                                              // Allows creating a product by specifying only the name and price. 
                                              // The quantity is initialized as zero by default, which can be useful when the initial stock is not necessary at the time of creation.
    {
        Name = name;
        Price = price;
        Quantity = 0; // Quantity is set to zero by default. I can also define a fixed quantity if needed.
    }

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
        return $"Product: {Name}, Price: {Price.ToString("F2", CultureInfo.InvariantCulture)}, {Quantity} units, Quantity in Stock: {TotalValueInStock().ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Enter the name of the product:");
        string name = Console.ReadLine();

        Console.WriteLine($"Enter the price of {name}:");
        double price = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

        // Console.WriteLine($"How many {name} do we have:"); This would be optional if I were using the constructor with 3 arguments.
        //int quantity = Convert.ToInt32(Console.ReadLine());

        Product p1 = new Product(name, price); // Instantiating the object based on the required constructor model - both with 3 arguments or the optional 2-argument version.
                                               // This is advantageous because it forces the essential information to be filled in at the time of object creation, reducing the chance of errors.

        Console.WriteLine(p1);
        Console.WriteLine(" ");

        Console.WriteLine($"Enter the quantity of {name} you will add:");
        int add = Convert.ToInt32(Console.ReadLine());
        p1.AddProduct(add);
        Console.WriteLine($"Updated data: {p1}");
        Console.WriteLine(" ");

        Console.WriteLine($"Enter the quantity of {name} you will remove:");
        int remove = Convert.ToInt32(Console.ReadLine());
        p1.RemoveProduct(remove);
        Console.WriteLine($"Updated data: {p1}");
    }

}
