using System;
using System.Globalization;
namespace Person
{

    public class People
    {
        public string name;
        public int age;
        
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            {

                People one,two;
                one = new People();
                two = new People();

                Console.WriteLine("Enter the name of person one:");

                one.name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter the age of person one:");
                one.age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the name of person two:");
                two.name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter the age of person one:");
                two.age = Convert.ToInt32(Console.ReadLine());
                

                if(one.age > two.age){
                    Console.WriteLine($" {one.name} is older");
                }else{
                    Console.WriteLine($" {two.name} is older");
                }
            }
        }
    }
}