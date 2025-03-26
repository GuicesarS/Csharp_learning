using System.Globalization;
using System;
class Product
{

    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture);
    }
}


class Program
{
    static void Main(string[] args)
    {

        List<Product> list = new List<Product>();

        list.Add(new Product("TV", 900.00));
        list.Add(new Product("Notebook", 1200.00));
        list.Add(new Product("Tablet", 450.00));

        // forma 1: list.Sort(CompareProducts); // criar uma função e usa ela mesmo como referencia = DELEGATE

        /* forma 2: 
        Comparison<Product> comp = CompareProducts; variavel guarda a referencia da função.
        list.Sort(comp);*/

        /* forma 3: Sem a função -> 
        Comparison<Product> comp = (p1,p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
        */

         forma 4: Sem a função -> list.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper())); // Lambda Inline

        foreach (Product p in list)
        {
            Console.WriteLine(p);
        }
    }
    /* static int CompareProducts(Product p1, Product p2)
    {
        return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
    }*/
}

