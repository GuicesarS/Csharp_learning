// FILE MANIPULATION

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var myFile = @"C:\Users\Guilherme.Soares\Desktop\baltaarquivosc#\file.txt";

        try
        {
            // string content = File.ReadAllText(myFile);
            // Console.WriteLine(content);
            // var content = File.ReadAllLines(myFile); // returns an array with the file content
            // foreach (var line in content)
            // {
            //     Console.WriteLine(line);
            // }

            using (StreamReader file = new StreamReader(myFile))
            {
                string data = file.ReadLine();
                Console.WriteLine(data);
                file.Close();
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error opening the file: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected error: " + e.Message);
        }
    }
}
