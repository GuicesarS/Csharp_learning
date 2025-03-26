using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = @"c:\Users\Guilherme.Soares\Desktop\StudyC#\Files.txt.txt";
        string destinationPath = @"c:\Users\Guilherme.Soares\Desktop\StudyC#\NewFileCreated.txt";

        try
        {
            FileInfo file = new FileInfo(sourcePath);
            file.CopyTo(destinationPath);
            Console.WriteLine("File copied successfully!");
            Console.WriteLine();

            // Instantiate an array where each position will hold a line read from the file
            string[] sourceLines = File.ReadAllLines(sourcePath);
            foreach (string lineRead in sourceLines)
            {
                Console.WriteLine(lineRead);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}
