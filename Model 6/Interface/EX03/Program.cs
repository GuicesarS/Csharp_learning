using System;
using System.Collections.Generic;
using System.Globalization;

// Definition of an interface for loan services.
// This allows any type of loan to implement its own installment calculation logic.
interface ILoanService
{
    double CalculateInstallments(double amount, int months);
}

// Implementation of personal loan.
// This class implements the ILoanService interface and defines the logic for calculating installments.
class PersonalLoan : ILoanService
{
    public double CalculateInstallments(double amount, int months)
    {
        // Applies a 3% fee to the total loan amount
        double amountWithFee = amount + (amount * 0.03);
        
        // Divides the amount with fee by the number of months to get the installment value
        return amountWithFee / months;
    }
}

// Implementation of payroll loan.
// Like personal loans, this class defines a lower rate (1.5%).
class PayrollLoan : ILoanService
{
    public double CalculateInstallments(double amount, int months)
    {
        // Applies a 1.5% fee to the total loan amount
        double amountWithFee = amount + (amount * 0.015);
        
        // Divides the amount with fee by the number of months to get the installment value
        return amountWithFee / months;
    }
}

// Implementation of business loan.
// Defines a higher rate (5%) since risks are usually higher.
class BusinessLoan : ILoanService
{
    public double CalculateInstallments(double amount, int months)
    {
        // Applies a 5% fee to the loan amount
        double amountWithFee = amount + (amount * 0.05);
        
        // Divides the amount with fee by the number of months to get the installment value
        return amountWithFee / months;
    }
}

// Class to store information about the user's loan request.
class LoanInfo
{
    public int AccountNumber { get; set; }  // Client's account number
    public double Amount { get; set; }      // Total loan amount
    public int Months { get; set; }         // Number of months for repayment

    // List that stores all calculated installments
    public List<double> Installments { get; private set; } = new List<double>();

    // Constructor to initialize loan data
    public LoanInfo(int accountNumber, double amount, int months)
    {
        AccountNumber = accountNumber;
        Amount = amount;
        Months = months;
    }

    // Method to add an installment amount to the list of installments
    public void AddInstallment(double installmentAmount)
    {
        Installments.Add(installmentAmount);
    }
}

// Class responsible for processing the loan and correctly calculating the installments.
class LoanService
{
    private ILoanService _loanService;  // Reference to the chosen loan service

    // Constructor receives a specific type of loan service
    public LoanService(ILoanService loanService)
    {
        _loanService = loanService;
    }

    // Method that processes the loan and adds the installments to the LoanInfo list
    public void ProcessLoan(LoanInfo loanInfo)
    {
        for (int i = 0; i < loanInfo.Months; i++)
        {
            // Calculates the installment value using the chosen loan service
            double installmentValue = _loanService.CalculateInstallments(loanInfo.Amount, loanInfo.Months);
            
            // Adds the installment value to the loan's installment list
            loanInfo.AddInstallment(installmentValue);
        }
    }
}

// Main program class that interacts with the user and processes loan data.
class Program
{
    static void Main()
    {
        try
        {
            // Asks the user for loan details
            Console.Write("Enter account number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Loan Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Number of months: ");
            int months = Convert.ToInt32(Console.ReadLine());

            // Asks what type of loan the user wants
            Console.Write("Loan type (1- Personal, 2- Payroll, 3- Business): ");
            int type = Convert.ToInt32(Console.ReadLine());

            // Variable to store the user's chosen loan type
            ILoanService chosenLoan;

            // Chooses the loan type based on the user's option
            switch (type)
            {
                case 1:
                    chosenLoan = new PersonalLoan();
                    break;
                case 2:
                    chosenLoan = new PayrollLoan();
                    break;
                case 3:
                    chosenLoan = new BusinessLoan();
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    return;
            }

            // Creates a loan object with the user's data
            LoanInfo loanInfo = new LoanInfo(accountNumber, amount, months);

            // Creates a loan service based on the user's choice
            LoanService service = new LoanService(chosenLoan);

            // Processes the loan and calculates the installments
            service.ProcessLoan(loanInfo);

            // Displays installment values and the total amount paid over the loan period
            Console.WriteLine("\nMonthly Loan Payments:");
            double total = 0;
            for (int i = 0; i < loanInfo.Installments.Count; i++)
            {
                Console.WriteLine($"Month {i + 1}: $ {loanInfo.Installments[i].ToString("F2", CultureInfo.InvariantCulture)}");
                total += loanInfo.Installments[i];
            }

            // Displays the total amount paid at the end of the loan
            Console.WriteLine($"\nTotal amount paid at the end of the loan: $ {total.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        catch (Exception ex)
        {
            // Catches any error and displays a friendly message to the user
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}