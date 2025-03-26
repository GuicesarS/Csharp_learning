using System;
using System.Collections.Generic;
using System.Globalization;

class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }

    public Product(string productName, double price)
    {
        ProductName = productName;
        Price = price;
    }

    public override string ToString()
    {
        return $"{ProductName} , R$ {Price.ToString("F2",CultureInfo.InvariantCulture)}";
    }

}
class Program
{
    static void Main(string[] args)
    {
        List<Product> list = new List<Product>();

        list.Add(new Product("Tv", 900.00));
        list.Add(new Product("Mouse", 50.00));
        list.Add(new Product("Tablet", 350.00));
        list.Add(new Product("HD case", 80.90));

        // Função lambda para remover: list.RemoveAll(p => p.Price >= 100.0);
        
        list.RemoveAll(ProductTest);
        foreach (Product p in list)
        {
            Console.WriteLine(p);
        }
    }
    public static bool ProductTest(Product p)
    {
        return p.Price >=100.0;
    }
}