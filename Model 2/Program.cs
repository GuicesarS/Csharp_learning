using System;
using System.Globalization;
namespace Triangle{
    public class Triangle
    {
        public double A;
        public double B;
        public double C;

        public double Area(){
            double p = (A + B + C) / 2;
            return Math.Sqrt(p*(p-A)*(p-B)*(p-C));

        }
        
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            {

                Triangle one,two;
                one = new Triangle();
                two = new Triangle();

                Console.WriteLine("Enter the A of first Triangle:");
                one.A = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Enter the B of first Triangle:");
                one.B = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Enter the C of first Triangle:");
                one.C = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Enter the A of Second Triangle:");
                two.A = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Enter the B of Second Triangle:");
                two.B = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Enter the C of Second Triangle:");
                two.C = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                double AreaX = one.Area();
                double AreaY = two.Area();

                Console.WriteLine($"The area of First Triangle is: {AreaX.ToString("F4", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"The area of Second Triangle is: {AreaY.ToString("F4", CultureInfo.InvariantCulture)}");

                if(AreaX > AreaY){
                    Console.WriteLine($"The area of First Triangle is greater than Second Triangle");
                }else{
                    Console.WriteLine($"The area of Second Triangle is greater than First Triangle");
                }

               
            }
        }
    }
}