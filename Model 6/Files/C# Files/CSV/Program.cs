using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

class Spreadsheet
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }

    public Spreadsheet(string name, string phone, DateTime birthday)
    {
        Name = name;
        Phone = phone;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return Name + "," + Phone + "," + Birthday.ToString("dd-MM-yyyy");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\Guilherme.Soares\Desktop\CSharpStudies\CSV\spreadsheet.csv";
        
        try
        {
            List<Spreadsheet> dataList = new List<Spreadsheet>
            {
                new("John Doe", "1234567890", DateTime.ParseExact("15-08-1995", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                new("Jane Smith", "9876543210", DateTime.ParseExact("22-03-1992", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
            };

            using (StreamWriter sw = File.AppendText(filePath))
            {
                foreach (Spreadsheet data in dataList)
                {
                    sw.WriteLine(data.ToString());
                }
            }

            Console.WriteLine("Spreadsheet created successfully!");
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating the spreadsheet: " + ex.Message);
        }
    }
}
