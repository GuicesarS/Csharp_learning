using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        HashSet<string> set = new HashSet<string>(); // Set instantiation
        set.Add("TV");
        set.Add("Laptop");
        set.Add("Cellphone");

        foreach (string s in set)
        {
            System.Console.WriteLine(s);
        }

        SortedSet<int> set2 = new SortedSet<int>{0,4,5,3,2,40};
        SortedSet<int> set3 = new SortedSet<int> {0,4,5,30,100,200};
        //PrintCollection(set2);

        // union of sets
        SortedSet<int> result = new SortedSet<int>(set2);
        result.UnionWith(set3); // Union without repetition
        PrintCollection(result); 

        // intersection of sets
        SortedSet<int> intersection = new SortedSet<int>(set2);
        intersection.IntersectWith(set3);
        PrintCollection(intersection);

        // difference of sets
        SortedSet<int> difference = new SortedSet<int>(set2);
        difference.ExceptWith(set3);
        PrintCollection(difference);
    }

    static void PrintCollection<T>(IEnumerable<T> collection)
    {
        foreach(T item in collection)
        {
            Console.Write(item + " ");
        }
    }

}
