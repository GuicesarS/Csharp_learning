using System;
using System.Globalization;

class AccountException : ApplicationException
{
    public AccountException(string message) : base(message) { }
}
class Account
{
    public int Number { get; set; }
    public string Holder { get; set; }
    public double Balance { get; private set; }
    public double Withdrawlimit { get; set; }

    public Account(int number, string holder, double balance, double Withdrawlimit)
    {
        Number = number;
        Holder = holder;
        Balance = balance;
        Withdrawlimit = Withdrawlimit;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void Withdraw(double amountinformed)
    {
        if (amountinformed > Balance)
        {
            throw new AccountException("Not enough balance");
        }
        if (amountinformed > Withdrawlimit)
        {
            throw new AccountException("Withdrawal limit exceeded");
        }
        else
        {
            Balance -= amountinformed;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter Account data: ");
        Console.Write("Account Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Account Holder: ");
        string holder = Console.ReadLine();
        Console.Write("Initial Balance: ");
        double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Withdraw Limit: ");
        double withdrawlimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Account account = new Account(number, holder, balance, withdrawlimit);

        Console.Write("Enter Amount for withdraw: ");

        double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        try
        {
            account.Withdraw(amount);
            Console.WriteLine($"New Balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");

        }
        catch (AccountException e)
        {
            Console.WriteLine($"Account Error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected Error: {e.Message}");
        }


    }
}