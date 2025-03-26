class Client
{
    public string Name { get; set; }
    public string Email { get; set; }

    public override bool Equals(object obj)
    {
        if (!(obj is Client))
        {
            return false;
        }
        Client other = obj as Client;
        return Email.Equals(other.Email);
    }

    public override int GetHashCode()
    {
        return Email.GetHashCode();
    }

    public Client() { }

}

class Program
{
    public static void Main(string[] args)
    {
        Client client1 = new Client
        {
            Name = "João",
            Email = "Joaozin@gmail.com"
        };
        Client client2 = new Client
        {
            Name = "Guilherme",
            Email = "guigas@gmail.com"
        };

        System.Console.WriteLine(client1.Equals(client2));
        System.Console.WriteLine(client1.GetHashCode());
        System.Console.WriteLine(client2.GetHashCode());
    }
}
