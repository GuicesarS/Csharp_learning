using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = @"c:\Users\Guilherme.Soares\Desktop\StudyC#\Files.txt.txt";
        try
        {
            // Using = executes the code inside and then automatically closes

            using (StreamReader sr = File.OpenText(path))
            // The variable sr will be responsible for reading the content of the file path.
            {
                while (!sr.EndOfStream) // The EndOfStream property returns 'true' if the end of the file is reached
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
                Console.WriteLine("Data read!");
            }

        }
        catch (IOException e)
        {
            Console.WriteLine("Error opening the file: " + e.Message);
        }
    }
}
