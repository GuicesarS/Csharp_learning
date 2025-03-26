using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = @"c:\Users\Guilherme.Soares\Desktop\Myfolder";

        try
        {
            // Gets an enumerable list of directories inside 'sourcePath'
            // - The first argument 'sourcePath' defines where the search will be performed.
            // - The second argument '*.*' defines the search pattern (not necessary for directories).
            // - The third argument 'SearchOption.AllDirectories' indicates that the search will be recursive, including subdirectories.

            var folders = Directory.EnumerateDirectories(sourcePath, "*.*", SearchOption.AllDirectories);

            Console.WriteLine("Folders found:");

            // Loops through the list of found directories
            foreach (string folderName in folders)
            {
                // Displays the path of each found directory in the console
                Console.WriteLine(folderName);
            }
            Console.WriteLine();

            var files = Directory.EnumerateFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            Console.WriteLine("Files found:");

            // Loops through the list of found files
            foreach (string fileName in files)
            {
                // Displays the path of each found file in the console
                Console.WriteLine(fileName);
            }

            // Create a folder
            Directory.CreateDirectory(sourcePath + @"\createdFolderVSCODE");
            Console.WriteLine("Folder successfully created!");
        }
        catch (IOException e)
        {
            Console.WriteLine("Error opening the file: " + e.Message);
        }
    }
}
