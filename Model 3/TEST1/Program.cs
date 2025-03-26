using System;
using System.Globalization;

public class Rectangle
{
    public double Height;
    public double Width;

    public double Area()
    {
        return Height * Width;
    }

    public double Perimeter()
    {
        return 2 * (Height + Width);
    }

    public double Diagonal()
    {
        return Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Width, 2));
    }

    public override string ToString()
    {
        return $"Height: {Height} - Width: {Width} AREA: {Area().ToString("F2", CultureInfo.InvariantCulture)} DIAGONAL: {Diagonal().ToString("F2", CultureInfo.InvariantCulture)} PERIMETER: {Perimeter().ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Rectangle rect = new Rectangle();
        Console.WriteLine("Enter the height of the rectangle:");
        rect.Height = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the width of the rectangle:");
        rect.Width = double.Parse(Console.ReadLine());

        rect.Area();
        rect.Diagonal();
        rect.Perimeter();

        Console.WriteLine(rect);
    }
}
