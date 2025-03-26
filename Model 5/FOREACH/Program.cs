using System;
class Program
{
    public static void Main(string[] args)
    {
        string[] names = new string[] { "Ana", "Lucas", "Maria", "Guilherme and Suzy Nenenzita" };
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}

/* 🔥 Quick comparison:
            Criterion          | for        | foreach
            Requires index?     | ✅ Yes     | ❌ No
            Can modify values?  | ✅ Yes (with index) | ⚠️ No directly
            Cleaner code?       | ❌ No     | ✅ Yes
            Works with any collection? | ✅ Yes   | ✅ Yes
*/
