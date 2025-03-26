using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> cookies = new Dictionary<string, string>();
        try
        {
            cookies["User"] = "Guilherme";
            cookies["Email"] = "guigas@gmail.com";
            cookies["Password"] = "123456";

            //cookies.Remove("Email");
            //Console.WriteLine(cookies["Email"]);
            //Console.Write($"Tamanho: {cookies.Count}");
            
            Console.WriteLine("COOKIES:");
            foreach (KeyValuePair<string, string> chave in cookies)
            // ou foreach (var chave in cookies)
            {
                Console.WriteLine(chave.Key + ": " + chave.Value);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

    }
}