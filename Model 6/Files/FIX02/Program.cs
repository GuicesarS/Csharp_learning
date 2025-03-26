using System;
using System.IO;
using System.Globalization;

class Student
{
    public string Name { get; set; }
    public double Grade1 { get; set; }
    public double Grade2 { get; set; }
    public double Grade3 { get; set; }

    public Student() { }
    public Student(string name, double grade1, double grade2, double grade3)
    {
        Name = name;
        Grade1 = grade1;
        Grade2 = grade2;
        Grade3 = grade3;
    }

    public double Average()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Path of the CSV file containing the student data
        string folder = @"C:\Users\Guilherme.Soares\Desktop\Estudoc#\Reviews\Files\FIX02\students.csv";

        try
        {
            // Store the data read from the file in an array
            string[] lines = File.ReadAllLines(folder); // Reads the data from the CSV file

            // Gets the directory where the file is located
            string fileDirectory = Path.GetDirectoryName(folder); // Gets the path of the file's folder
            string outputFolder = (fileDirectory + @"\output"); // Defines the path of the output folder
            string outputFile = (outputFolder + @"\grades.csv"); // Defines the path of the output file in the folder

            // Creates the output folder if it does not exist
            Directory.CreateDirectory(outputFolder);

            // Uses StreamWriter to write to the output file
            using (StreamWriter sw = File.AppendText(outputFile)) // Opens the file for appending content
            {
                foreach (string line in lines)
                {
                    string[] fields = line.Split(",");
                    string name = fields[0];
                    double grade1 = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    double grade2 = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    double grade3 = double.Parse(fields[3], CultureInfo.InvariantCulture);
                    Student student = new Student(name, grade1, grade2, grade3);

                    sw.WriteLine($"Student: {student.Name} - Semester Average: {student.Average().ToString("F2", CultureInfo.InvariantCulture)}");
                }
            }

        }
        catch (IOException e)
        {
            Console.WriteLine("IO Error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected Error: " + e.Message);
        }

    }
}
