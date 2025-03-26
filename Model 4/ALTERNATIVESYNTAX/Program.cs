using System;
using System.Globalization;

public class Product
{
    public string Name;
    public double Price;
    public int Quantity;

    public Product(string name, double price, int quantity) // Forces the user to provide the details for the product, avoiding products without a price, name, or quantity. 
    // This helps because if the user doesn't provide these details, the program may throw an error.
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public Product(string name, double price) // Optional constructor
                                              // Allows creating a product by providing only the name and price. 
                                              // The quantity is initialized to zero by default, which can be useful in cases where the initial stock is not necessary when the product is created.
    {
        Name = name;
        Price = price;
        Quantity = 0; // Quantity is set to zero by default. A fixed quantity can also be defined if needed.
    }

    public Product()
    {
    }

    public int AddProduct(int quantity)
    {
        return Quantity += quantity;
    }

    public int RemoveProduct(int quantity)
    {
        return Quantity -= quantity;
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
    public static void Main(string[] agrs)
    {

        Product pTestProductFix = new Product()
        {
            Name = "Cement", // Simulating a scenario where a fixed product (cement) is registered with a defined price and an initial stock of zero.
            Price = 25.90,
            // Quantity is not necessary here, because the default constructor already initializes it to zero.
            // This approach is useful for products whose stock will be updated later.
        };

        Console.WriteLine(pTestProductFix);
        Console.WriteLine(" ");

        Console.WriteLine($"Enter the quantity of {pTestProductFix.Name} you will add:");
        int add = Convert.ToInt32(Console.ReadLine());
        pTestProductFix.AddProduct(add);
        Console.WriteLine(" ");

        Console.WriteLine($"Updated data: {pTestProductFix}");
        Console.WriteLine(" ");

        Console.WriteLine($"Enter the quantity of {pTestProductFix.Name} you will remove:");
        int remove = Convert.ToInt32(Console.ReadLine());
        pTestProductFix.RemoveProduct(remove);
        Console.WriteLine($"Updated data: {pTestProductFix}"); // Prints the information from the ToString method with updated data after additions and 
        // subtractions.

        DateTime now = DateTime.Now; // Display the current date

        if (pTestProductFix.Quantity == 0)
        {
            Console.WriteLine($"All units of {pTestProductFix.Name} have been sold! Please wait for the next restock.");
        }
        Console.WriteLine(" ");
        Console.WriteLine($"Gross Total Sold on {now}: $ {(pTestProductFix.Price * remove).ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine(" ");

        if (pTestProductFix.Quantity != 0)
        {
            Console.WriteLine($" {remove} units were sold / {pTestProductFix.Quantity} units remaining in stock.");
        }

        /* 
         Line 78 - Console.WriteLine($"Updated data: {pTestProductFix}"); prints the updated quantity directly, 
         so the subtraction (add - remove) is not necessary. The remaining quantity is correctly reflected in pTestProductFix.Quantity 
         after the operations.
        */
    }

}
