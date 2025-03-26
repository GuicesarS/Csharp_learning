using System;
class CalculationService
{
    public static double Max(double x, double y)
    {
        return (x > y) ? x : y;
    }
    public static double Sum(double x, double y)
    {
        return x + y;
    }
    public static double Square(double x)
    {
        return x * x;
    }
}
delegate double BinaryNumericOperation(double x, double y);
class Program
{
    public static void Main(string[] args)
    {
        double a = 10;
        double b = 20;

        BinaryNumericOperation op = CalculationService.Sum;

        double result = op.Invoke(a,b);

        // Invoke executa todos os metodos na ordem que foram adicionados.
        Console.WriteLine(result);
    }
}