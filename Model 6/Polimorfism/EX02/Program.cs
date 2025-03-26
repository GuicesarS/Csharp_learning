using System;
using System.Collections.Generic;
using System.Globalization;
 class Product
{
    public string NameProduct { get; set; }
    public double PriceProduct { get; set; }

    public Product() { }
    public Product(string nameproduct, double priceproduct)
    {
        NameProduct = nameproduct;
        PriceProduct = priceproduct;
    }

    public virtual string PriceTag()
    {
        return $" {NameProduct} - ${PriceProduct}";
    }
}

class ImportedProduct : Product
{
    public double CostumsFee { get; set; }

    public ImportedProduct() { }
    public ImportedProduct(string nameproduct, double priceproduct, double costumsfee)
    : base(nameproduct, priceproduct)
    {
        CostumsFee = costumsfee;
    }

    public override String PriceTag()
    {
        return $" {NameProduct} - Total Payment: {TotalPrice()} - (Customs Fee: ${CostumsFee}) ";
    }

    public double TotalPrice()
    {
        return PriceProduct + CostumsFee;
    }

}

class UsedProduct : Product
{
    public DateTime ManufactureDate { get; set; }

    public UsedProduct() { }

    public UsedProduct(string nameproduct, double priceproduct, DateTime manufacturedate)
    : base(nameproduct, priceproduct)
    {
        ManufactureDate = manufacturedate;
    }

    public override String PriceTag()
    {
        return $" {NameProduct} (Used) - ${PriceProduct} - (Manufacture date: {ManufactureDate.ToString("dd/MM/yyyy")})";
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Product> Listofproducts = new List<Product>();

        Console.Write("Enter number of products: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter {i + 1} data: ");
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter product type (Common (c) / Used (u) / Imported (i)): ");
            char type = char.Parse(Console.ReadLine());
            type = char.ToUpper(type);

            if (type == 'U')
            {
                Console.Write("Enter manufacture date (dd/mm/yyyy): ");
                DateTime manufacturedate = DateTime.Parse(Console.ReadLine());
                manufacturedate = manufacturedate.Date;
                Listofproducts.Add(new UsedProduct(name, price, manufacturedate));
            }
            else if (type == 'I')
            {
                Console.Write("Enter import tax (Costums Fee): ");
                double tax = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Listofproducts.Add(new ImportedProduct(name, price, tax));
            }
            else
            {
                Listofproducts.Add(new Product(name, price));
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("PRODUCTS: ");
        foreach (Product item in Listofproducts)
        {
 
           Console.WriteLine(item.PriceTag());
        }
    }
}
