// FILE MANIPULATION

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string myFile = @"C:\Users\Guilherme.Soares\Desktop\baltaarquivosc#\file.txt";
        string anotherFile = @"C:\Users\Guilherme.Soares\Desktop\baltaarquivosc#\another.txt";
        // string moveToLocation = @"C:\Users\Guilherme.Soares\Desktop\baltaarquivosc#\newFileLocation.txt";

        try
        {
            // File.Create(myFile); // creating a file

            /* using (StreamWriter sw = File.AppendText(myFile))
                {
                     sw.WriteLine("Writing at the end of an existing file with File.AppendText()");
                }
                Console.WriteLine("File updated");
            */

            /* using (StreamWriter sw = File.CreateText(myFile))
                 {
                    sw.WriteLine("Replacing the file with File.CreateText()");
                 }
                 Console.WriteLine("File updated");
            */

            // File.Copy(myFile, anotherFile); // copy file (source, destination)

            /* File.Move(anotherFile, moveToLocation); // move file (source, destination)
                System.Console.WriteLine("File moved.");
            */

            // File.Delete(moveToLocation); // delete file

            // File.Exists(myFile); // returns a boolean  

            /* DateTime lastAccess = File.GetLastAccessTime(myFile);
                Console.WriteLine(lastAccess); // shows the last time the document was accessed       
            */        
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
