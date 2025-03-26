using System;
using System.Collections.Generic;
using System.Globalization;

interface ISubscriptionService
{
    double CalculateFee(double monthlyFee);
}

class BasicPlan : ISubscriptionService
{
    public double CalculateFee(double monthlyFee) => monthlyFee * 0.02;
}

class StandardPlan : ISubscriptionService
{
    public double CalculateFee(double monthlyFee) => monthlyFee * 0.05;
}

class PremiumPlan : ISubscriptionService
{
    public double CalculateFee(double monthlyFee) => monthlyFee * 0.08;
}

class Subscription
{
    public int Number { get; set; }
    public double MonthlyFee { get; set; }
    public int Months { get; set; }
    public List<double> MonthlyPayments { get; private set; } = new List<double>();

    public Subscription(int number, double monthlyFee, int months)
    {
        Number = number;
        MonthlyFee = monthlyFee;
        Months = months;
    }

    public void AddMonthlyPayment(double amount)
    {
        MonthlyPayments.Add(amount);
    }
}

class SubscriptionService
{
    private ISubscriptionService _service;

    public SubscriptionService(ISubscriptionService service)
    {
        _service = service;
    }

    public void ProcessSubscription(Subscription subscription)
    {
        for (int i = 0; i < subscription.Months; i++)
        {
            double fee = _service.CalculateFee(subscription.MonthlyFee);
            double finalAmount = subscription.MonthlyFee + fee;
            subscription.AddMonthlyPayment(finalAmount);
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Subscription number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Choose a plan (1 - Basic, 2 - Standard, 3 - Premium): ");
            int option = int.Parse(Console.ReadLine());

            Console.Write("Number of months: ");
            int months = int.Parse(Console.ReadLine());

            ISubscriptionService selectedPlan;
            double planPrice;

            switch (option)
            {
                case 1:
                    selectedPlan = new BasicPlan();
                    planPrice = 50.00;
                    break;
                case 2:
                    selectedPlan = new StandardPlan();
                    planPrice = 75.00;
                    break;
                case 3:
                    selectedPlan = new PremiumPlan();
                    planPrice = 100.00;
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    return;
            }

            Subscription subscription = new Subscription(number, planPrice, months);
            SubscriptionService service = new SubscriptionService(selectedPlan);
            service.ProcessSubscription(subscription);

            Console.WriteLine("\nMonthly Payments:");
            double total = 0;
            for (int i = 0; i < months; i++)
            {
                Console.WriteLine($"Month {i + 1}: $ {subscription.MonthlyPayments[i].ToString("F2", CultureInfo.InvariantCulture)}");
                total += subscription.MonthlyPayments[i];
            }

            Console.WriteLine($"\nTotal paid at the end: $ {total.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
