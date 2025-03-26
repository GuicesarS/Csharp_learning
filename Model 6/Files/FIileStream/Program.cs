using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = @"c:\Users\Guilherme.Soares\Desktop\StudyC#\Files.txt.txt";
        StreamReader sr = null;

        try
        {
            // Opens the text file for reading and returns a StreamReader
            sr = File.OpenText(path); // Method that simplifies opening text files for reading

            // While not at the end of the file
            while (!sr.EndOfStream) // The EndOfStream property returns 'true' if the end of the file is reached
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            Console.WriteLine("Data read!");

        }
        catch (Exception e)
        {
            Console.WriteLine("Error opening the file: " + e.Message);
        }
        finally
        {
            if (sr != null) sr.Close();
        }
    }
}
