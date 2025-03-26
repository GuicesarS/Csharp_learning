using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args) // Fixed the parameter name
    {
        // Creating a list of fruits
        List<string> fruitList = new List<string>();
        fruitList.Add("Mango");
        fruitList.Add("Banana");
        fruitList.Insert(1, "Grapes");
        fruitList.Add("Strawberry");
        fruitList.Insert(3, "Passion Fruit");
        fruitList.Add("Watermelon");

        // Displaying all fruits in the list
        Console.WriteLine("Fruit List:");
        foreach (string fruit in fruitList)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine($"\nNumber of elements in the list: {fruitList.Count}");

        // Finding the first word starting with 'M'
        string firstWithM = fruitList.Find(x => x[0] == 'M');
        Console.WriteLine($"\nFirst fruit with 'M': {firstWithM}");

        // Finding the last word starting with 'M'
        string lastWithM = fruitList.FindLast(x => x[0] == 'M');
        Console.WriteLine($"\nLast fruit with 'M': {lastWithM}");

        int firstPosWithM = fruitList.FindIndex(x => x[0] == 'M');
        Console.WriteLine($"\nFirst position of the fruit with 'M': {firstPosWithM} - Name: {firstWithM}");

        int lastPosWithM = fruitList.FindLastIndex(x => x[0] == 'M');
        Console.WriteLine($"\nLast position of the fruit with 'M': {lastPosWithM} - Name: {lastWithM}");

        List<string> specificFruitList = fruitList.FindAll(x => x[0] == 'M');

        Console.WriteLine("Specific Fruit List:");
        foreach (string specificFruit in specificFruitList)
        {
            Console.WriteLine(specificFruit);
        }
        Console.WriteLine("-------------------------------------");
        fruitList.RemoveRange(0, 3);
        Console.WriteLine("Updated Fruit List:");
        foreach (string fruit in fruitList)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine("-------------------------------------");
        fruitList.Remove("Watermelon");
        Console.WriteLine("Fruit List:");
        foreach (string fruit in fruitList)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine("-------------------------------------");
        fruitList.RemoveAll(x => x[0] == 'M');
        Console.WriteLine("Fruit List:");
        foreach (string fruit in fruitList)
        {
            Console.WriteLine(fruit);
        }
    }
}
