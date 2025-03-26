// Implementation Order

// Private attributes
// Auto-implemented properties
// Constructors
// Custom properties
// Methods 

using System;
using System.Globalization;

public class Bank
{
    // Private attributes
    private string _accountHolderName;
    public int AccountNumber { get; private set; } // Cannot be changed
    public double Balance { get; private set; } // Cannot be changed

    public Bank(string name, int accountNumber, double balance) // Main constructor in case of initial deposit
    {
        _accountHolderName = name;
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public Bank(string name, int accountNumber) : this(name, accountNumber, 0) { } // Optional constructor in case there is no initial deposit

    // Check name 
    public string AccountHolderName
    {
        get { return _accountHolderName; }
        set
        {
            if (value != null && value.Length > 0)  // Correct check: name cannot be null or empty
            {
                _accountHolderName = value;
            }
        }
    }

    public override string ToString()
    {
        return $"Account: {AccountNumber} - Holder: {_accountHolderName} - Balance: {Balance.ToString("F2", CultureInfo.InvariantCulture)}"; // Return account holder info
    }

    public void Deposit(double amount)
    {
        Balance += amount; // Modify the Balance field
    }

    public void Withdraw(double amount) // Withdrawal fee of $5
    {
        Balance -= (amount + 5); // Modify the Balance field
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the account number:");
        int num = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the account holder's name:");
        string name = Console.ReadLine();

        Bank client1;

        Console.WriteLine("Will there be an initial deposit: Y/N?");
        string dep = Console.ReadLine();

        while (dep != "Y" && dep != "y" && dep != "N" && dep != "n")
        {
            Console.WriteLine("Invalid option. Please check the data and try again.");
            Console.WriteLine("Will there be an initial deposit: Y/N?");
            dep = Console.ReadLine();
        }

        if (dep == "Y" || dep == "y")
        {
            Console.WriteLine("Enter the deposit amount:");
            double deposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            client1 = new Bank(name, num, deposit);
        }
        else
        {
            client1 = new Bank(name, num);
        }

        Console.WriteLine($"Account Data: {client1.ToString()}");
        Console.WriteLine(" ");

        Console.WriteLine("Enter the deposit amount to be made:");
        double depositMain = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        client1.Deposit(depositMain);

        Console.WriteLine($"Updated Data: {client1.ToString()}");
        Console.WriteLine(" ");

        Console.WriteLine("Enter the withdrawal amount to be made:");
        double withdrawMain = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        client1.Withdraw(withdrawMain);
        Console.WriteLine($"Updated Data: {client1.ToString()}");
        Console.WriteLine(" ");
    }
}
