using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = @"c:\Users\Guilherme.Soares\Desktop\Estudoc#\Arquivocs.txt.txt";
        string destinationPath = @"c:\Users\Guilherme.Soares\Desktop\teste\teste2.txt";

        try
        {
            string[] lines = File.ReadAllLines(sourcePath);

             using (StreamWriter sw = File.AppendText(destinationPath))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line.ToUpper());
                }

            }
        }           
        catch (IOException e)
        {
            Console.WriteLine("Erro ao abrir o arquivo: " + e.Message);
        }

        
    }
}
