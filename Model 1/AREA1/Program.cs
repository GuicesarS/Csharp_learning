using System;
using System.Globalization;
namespace area_triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            {
                Console.WriteLine("Enter the base of the triangle X:");
                double base_trianglex1 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                double base_trianglex2 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                double base_trianglex3 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Enter the base of the triangle Y:");
                double base_triangley1 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                double base_triangley2 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                double base_triangley3 = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);


                double px = (base_trianglex1 + base_trianglex2 + base_trianglex3) / 2;
                double areaX = Math.Sqrt(px * (px - base_trianglex1) * (px - base_trianglex2) * (px - base_trianglex3));
                Console.WriteLine("Triangle X Area:");
                Console.WriteLine(areaX.ToString("F4", CultureInfo.InvariantCulture));

                double py = (base_triangley1 + base_triangley2 + base_triangley3) / 2;
                double areaY = Math.Sqrt(py * (py - base_triangley1) * (py - base_triangley2) * (py - base_triangley3));
                Console.WriteLine("Triangle Y Area:");
                Console.WriteLine(areaY.ToString("F4", CultureInfo.InvariantCulture));

                if(areaX > areaY){
                    Console.WriteLine("Triangle X is larger");
                }else{
                    Console.WriteLine("Triangle Y is larger");
                }

            }
        }
    }
}