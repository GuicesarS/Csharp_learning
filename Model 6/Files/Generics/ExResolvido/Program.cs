using System;
using System.IO;

class LogRecord
{
    public string Name { get; set; }
    public DateTime AccessDate { get; set; }

    public LogRecord(string name, DateTime accessDate)
    {
        Name = name;
        AccessDate = accessDate;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        if (!(obj is LogRecord))
        {
            return false;
        }
        LogRecord other = obj as LogRecord;
        return Name.Equals(other.Name);
    }
}
class Program
{
    static void Main(string[] args)
    {
        HashSet<LogRecord> set = new HashSet<LogRecord>();

        Console.Write("Enter the file location: ");
        string file = Console.ReadLine();

        try
        {
            using (StreamReader sr = File.OpenText(file))
            {
                while(!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    string name = line[0];
                    DateTime moment = DateTime.Parse(line[1]);
                    set.Add(new LogRecord(name, moment));
                }
                Console.WriteLine($"Total visitors on the site: {set.Count}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error opening the file: " + ex.Message);
        }
    }
}
