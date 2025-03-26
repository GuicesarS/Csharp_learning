using System;

class DomainException : ApplicationException
{

    public DomainException(string message) : base(message)
    {
    }
}
class Reservation
{

    public int RoomNumber { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }

    public Reservation()
    {
    }

    public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
    {

        if (checkOut <= checkIn)
        {
            throw new DomainException("Check-out date must be after check-in date");
        }

        RoomNumber = roomNumber;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public double Duration()
    {
        // Calcula a diferença entre as datas de check-in e check-out
        // O método Subtract retorna um TimeSpan que representa esse intervalo
        TimeSpan duration = CheckOut.Subtract(CheckIn);

        // Retorna a diferença total de dias como um número inteiro
        // A propriedade TotalDays retorna um valor double, mas o casting para (int) remove a parte decimal
        return (int)duration.TotalDays;

    }

    public void UpdateDates(DateTime checkIn, DateTime checkOut)
    {

        DateTime now = DateTime.Now;
        if (checkIn < now || checkOut < now)
        {
            throw new DomainException("Reservation dates for update must be future dates");
        }
        else if (checkOut <= checkIn)
        {
            throw new DomainException("Check-out date must be after check-in date");
        }

        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public override string ToString()
    {
        return "Room "
            + RoomNumber
            + ", check-in: "
            + CheckIn.ToString("dd/MM/yyyy")
            + ", check-out: "
            + CheckOut.ToString("dd/MM/yyyy")
            + ", "
            + Duration()
            + " nights";
    }
}

class Program
{
    static void Main(string[] args)
    {

        try
        {
            Console.Write("Room number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            Reservation reservation = new Reservation(number, checkIn, checkOut);
            Console.WriteLine("Reservation: " + reservation);

            Console.WriteLine();
            Console.WriteLine("Enter data to update the reservation:");
            Console.Write("Check-in date (dd/MM/yyyy): ");
            checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            checkOut = DateTime.Parse(Console.ReadLine());

            reservation.UpdateDates(checkIn, checkOut);
            Console.WriteLine("Reservation: " + reservation);
        }
        catch (FormatException e)
        {
            Console.WriteLine("Error in format: " + e.Message);
        }
        catch (DomainException e)
        {
            Console.WriteLine("Error in reservation: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Unexpected error: " + e.Message);
        }
    }
}