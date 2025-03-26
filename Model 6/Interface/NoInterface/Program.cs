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

    override public string ToString()
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

class BrazilTaxService
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
    private BrazilTaxService _brazilTaxService = new BrazilTaxService();
    public RentalService(double pricePerHour, double pricePerDay)
    {
        PricePerHour = pricePerHour;
        PricePerDay = pricePerDay;
    }
    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
        double basicPayment = 0;

        if (duration.TotalHours <= 12.0)
        {
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); //ceiling arredonda o pra cima
        }
        else
        {
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        }

        double tax = _brazilTaxService.Tax(basicPayment);

        carRental.Invoice = new Invoice(basicPayment, tax);
    }
}

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Enter rental data: ");
        System.Console.WriteLine("Car Model: ");
        string carModel = System.Console.ReadLine();
        System.Console.WriteLine("Pickup (dd/MM/yyyy hh:mm)");
        DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        System.Console.WriteLine("Return (dd/MM/yyyy hh:mm)");
        DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        CarRental rental = new CarRental(start, finish, new Vehicle(carModel));

        System.Console.WriteLine("Enter the price per hour: ");
        double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        System.Console.WriteLine("Enter price per day: ");
        double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        RentalService rentalService = new RentalService(pricePerHour, pricePerDay);
        rentalService.ProcessInvoice(rental);

        System.Console.WriteLine(rental.Invoice);

    }
}