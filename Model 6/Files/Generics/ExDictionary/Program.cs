using System.Collections.Generic;
using System;
using System.IO;

class Votes
{
    public string Name { get; set; }
    public int Vote { get; set; }
    public Votes(string name, int vote)
    {
        Name = name;
        Vote = vote;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        if(!(obj is Votes))
        {
            return false;
        }
        Votes otherVote = obj as Votes;
        return Name.Equals(otherVote.Name);
    }
}
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter the file location: ");
            string file = Console.ReadLine();

            using (StreamReader sr = File.OpenText(file))
            {
                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                while(!sr.EndOfStream)
                {
                    string[] storeVotes = sr.ReadLine().Split(',');
                    string candidate = storeVotes[0]; // key
                    int votes = int.Parse(storeVotes[1]); // value
                   
                    if(dictionary.ContainsKey(candidate)) // if the candidate is repeated
                    {
                        dictionary[candidate] += votes; // add the votes
                    }
                    else
                    {
                        dictionary[candidate] = votes; // keep as is
                    }
                }

                foreach(var displayVote in dictionary)
                {
                    Console.WriteLine(displayVote.Key + ": " + displayVote.Value);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
