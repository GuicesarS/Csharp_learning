using System;

class PrintService<T>
{
    private T[] _values = new T[10];
    private int _count = 0;

    public void AddValue(T value)
    {
        if (_count == 10)
        {
            throw new InvalidOperationException("Array is already full.");
        }
        _values[_count] = value;
        _count++;
    }

    public T First()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Array is empty.");
        }
        return _values[0];
    }

    public void Print()
    {
        Console.Write("[");
        for (int i = 0; i < (_count - 1); i++)
        {
            Console.Write(_values[i] + ",");
        }
        if (_count > 0)
        {
            Console.Write(_values[_count - 1]);
        }
        Console.Write("]");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PrintService<int> service = new PrintService<int>();
        Console.Write("How many values: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int x = int.Parse(Console.ReadLine());
            service.AddValue(x);
        }

        service.Print();
        Console.WriteLine($"\nFirst: {service.First()}");
    }
}
