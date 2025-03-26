using System.Collections.Generic;
using System.IO;
using System;

class Fruits
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Fruits(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Fruits))
        {
            return false;
        }
        Fruits other = obj as Fruits;
        return Name.Equals(other.Name);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        string file = @"C:\Users\Guilherme.Soares\Desktop\StudyC#\Reviews\Generics\ExDictionary2\fruits.txt";
        try
        {

            using (StreamReader sr = File.OpenText(file))
            {
                Dictionary<string, int> dic = new Dictionary<string, int>();

                while (!sr.EndOfStream)
                {
                    string[] info = sr.ReadLine().Split(',');
                    string name = info[0]; // Key
                    int quantity = int.Parse(info[1]); // Value

                    if (dic.ContainsKey(name))
                    {
                        dic[name] += quantity; // I take my key "Name" and add the value "Quantity" to that key, which is the quantity of fruits
                    }
                    else
                    {
                        dic[name] = quantity;
                    }
                }
                foreach(var showFruits in dic)
                {
                    Console.WriteLine(showFruits.Key + " " + showFruits.Value);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
