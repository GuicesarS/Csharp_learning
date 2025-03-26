using System;
class CalculationService
{
    public static void ShowMax(double x, double y)
    {
        double max = (x > y) ? x : y;
        Console.WriteLine(max);
    }
    public static void ShowSum(double x, double y)
    {
        double sum = x + y;
        Console.WriteLine(sum);
    }
}
delegate void BinaryNumericOperation(double x, double y);
class Program
{
    public static void Main(string[] args)
    {
        double a = 10;
        double b = 20;

        BinaryNumericOperation op = CalculationService.ShowSum;
        op += CalculationService.ShowMax;

        op.Invoke(a,b);

        // Invoke executa todos os metodos na ordem que foram adicionados.
        
    }
}