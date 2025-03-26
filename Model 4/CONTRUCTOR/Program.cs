using System;
using System.Globalization;

public class Product
{
    public string Name;
    public double Price;
    public int Quantity;

    public Product(string name, double price, int quantity) // Forces the user to specify how the object will behave to avoid having a product without price, name, or quantity. 
    // This helps because, if the user does not provide these details, the program may throw an error.
    {
        Name = name;
        Price = price;
        Quantity = quantity;
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
        // Since I am using a constructor, I will need to remove and use auxiliary and temporary variables because
        // the constructor requires the values to be defined at the time of object creation, ensuring data integrity and consistency.

        // Example to be removed:

        // Product p1 = new Product("TV", 19.90, 16);
        // Console.WriteLine(p1);

        Console.WriteLine("Enter the name of the product:");
        string name = Console.ReadLine();

        Console.WriteLine($"Enter the price of {name}:");
        double price = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine($"How many {name} do we have:");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Product p1 = new Product(name, price, quantity); // Instantiating the object in the model required by the constructor.
                                                         // This is advantageous because it forces the essential information to be filled out at the time of object creation, reducing the chance of errors.

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
