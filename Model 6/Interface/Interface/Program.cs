using System;
using System.Globalization;

class Vehicle
{
    public string Model { get; set; }
    public Vehicle() { }
    public Vehicle(string model)
    {
        Model = model;
    }
}

class Invoice
{
    public double BasicaPayment { get; set; }
    public double Tax { get; set; }

    public Invoice() { }
    public Invoice(double basicaPayment, double tax)
    {
        BasicaPayment = basicaPayment;
        Tax = tax;
    }
    public double TotalPayment
    {
        get { return BasicaPayment + Tax; }
    }

    public override string ToString()
    {
        return $"Basic Payment: {BasicaPayment.ToString("F2", CultureInfo.InvariantCulture)} \nTax: {Tax.ToString("F2", CultureInfo.InvariantCulture)} \nTotal Payment: {TotalPayment.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}

class CarRental
{
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public Vehicle Vehicle { get; set; }
    public Invoice Invoice { get; set; }

    public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
    {
        Start = start;
        Finish = finish;
        Vehicle = vehicle;
    }
}

interface ITaxService
{
    double Tax(double amount);
}

class BrazilTaxService : ITaxService
{
    public double Tax(double amount)
    {
        if (amount <= 100)
        {
            return amount * 0.2;
        }
        else
        {
            return amount * 0.15;
        }
    }
}

class RentalService
{
    public double PricePerHour { get; private set; }
    public double PricePerDay { get; private set; }
    private ITaxService _taxService;

    public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
    {
        PricePerHour = pricePerHour;
        PricePerDay = pricePerDay;
        _taxService = taxService;
    }

    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
        double basicPayment = 0;

        if (duration.TotalHours <= 12.0)
        {
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        }
        else
        {
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        }

        double tax = _taxService.Tax(basicPayment);
        carRental.Invoice = new Invoice(basicPayment, tax);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter rental data: ");
        Console.Write("Car Model: ");
        string carModel = Console.ReadLine();
        
        Console.Write("Pickup (dd/MM/yyyy HH:mm): ");
        DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        
        Console.Write("Return (dd/MM/yyyy HH:mm): ");
        DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        CarRental rental = new CarRental(start, finish, new Vehicle(carModel));

        Console.Write("Enter the price per hour: ");
        double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        
        Console.Write("Enter price per day: ");
        double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        RentalService rentalService = new RentalService(pricePerHour, pricePerDay, new BrazilTaxService());
        rentalService.ProcessInvoice(rental);

        Console.WriteLine("\nINVOICE:");
        Console.WriteLine(rental.Invoice);
    }
}
