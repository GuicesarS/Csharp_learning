using System;
using System.Globalization;
using System.Collections.Generic;

class Contract
{
    public int AccountNumber { get; set; }
    public DateTime ContractDate { get; set; }
    public double TotalAmount { get; set; }
    public List<Installment> Installments { get; set; }

    public Contract()
    {
        Installments = new List<Installment>();
    }

    public Contract(int accountNumber, DateTime contractDate, double totalAmount)
    {
        AccountNumber = accountNumber;
        ContractDate = contractDate;
        TotalAmount = totalAmount;
        Installments = new List<Installment>();
    }

    public void AddInstallment(Installment installment)
    {
        Installments.Add(installment);
    }
}

class Installment
{
    public DateTime DueDate { get; set; }
    public double Amount { get; set; }

    public Installment() { }

    public Installment(DateTime dueDate, double amount)
    {
        DueDate = dueDate;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{DueDate.ToString("dd/MM/yyyy")} - {Amount.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

interface IOnlinePaymentService
{
    /*
       The IOnlinePaymentService interface acts as a contract defining what an online payment service must do but not how.
       This means any online payment service must implement this contract and define methods for calculating interest and fees.
    */
    double Interest(double amount, int months);
    double PaymentFee(double amount);
}

class PaypalPaymentService : IOnlinePaymentService
{
    /*
        The PaypalPaymentService class implements this interface, defining how interest and fees are calculated using PayPal.
    */
    public double Interest(double amount, int months)
    {
        return amount * 0.01 * months;
    }

    public double PaymentFee(double amount)
    {
        return amount * 0.02;
    }

    /*
        If the company decides to switch to another payment service in the future (like Stripe or Mercado Pago),
        a new class can be created without modifying the contract code.
    */
}

class ContractService
{
    private IOnlinePaymentService _paymentService; // Any payment service implementing the interface can be used here

    public ContractService(IOnlinePaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public void ProcessContract(Contract contract, int months)
    {
        double baseInstallmentAmount = contract.TotalAmount / months;

        for (int i = 1; i <= months; i++)
        {
            DateTime dueDate = contract.ContractDate.AddMonths(i);
            double interestAmount = baseInstallmentAmount + _paymentService.Interest(baseInstallmentAmount, i);
            double finalAmount = interestAmount + _paymentService.PaymentFee(interestAmount);

            contract.AddInstallment(new Installment(dueDate, finalAmount));
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Contract number: ");
        int contractNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Contract date (dd/MM/yyyy): ");
        DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Total contract amount: ");
        double totalAmount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine("Number of months: ");
        int months = int.Parse(Console.ReadLine());

        Contract contract = new Contract(contractNumber, contractDate, totalAmount);

        ContractService contractService = new ContractService(new PaypalPaymentService());
        contractService.ProcessContract(contract, months);

        Console.WriteLine("\nInstallments:");
        foreach (Installment installment in contract.Installments)
        {
            Console.WriteLine(installment);
        }
    }
}
