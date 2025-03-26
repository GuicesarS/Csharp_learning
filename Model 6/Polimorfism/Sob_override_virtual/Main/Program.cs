using System;
    class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account(1001, "Alex", 500.0); // conta comum com taxa
            Account acc2 = new SavingsAccount(1002, "Anna",500.0, 0.01); // conta poupança sem taxa

            acc1.Withdraw(10.0);
            acc2.Withdraw(100.0);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);
        }
     }
    
