using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // path = performs operations with strings that contain file or folder information.
        string path = @"c:\Users\Guilherme.Soares\Desktop\Myfolder\Pasta1\pasta1.1";

        Console.WriteLine($"Character for separation: {Path.DirectorySeparatorChar}");
        Console.WriteLine($"Separator: {Path.PathSeparator}");
        Console.WriteLine($"Get the file name where I am: {Path.GetFileName(path)}");
        Console.WriteLine($"Directory name where the file is: {Path.GetDirectoryName(path)}");
        Console.WriteLine($"Get the file name without extension: {Path.GetFileNameWithoutExtension(path)}");
        Console.WriteLine($"Get the file extension where I am: {Path.GetExtension(path)}");
        Console.WriteLine($"General information about the file where I am: {Path.GetFullPath(path)}");
        Console.WriteLine($"System's temporary folder where I can manipulate temporary application data: {Path.GetTempPath()}");
    }
}
