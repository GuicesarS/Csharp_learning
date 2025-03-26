using System;
using System.Collections.Generic;

enum OrderStatus : int
{
    PendingPayment = 0,
    Processing = 1,
    Shipped = 2,
    Delivered = 3
}
class Order
{
    public int Id { get; set; }
    public DateTime Moment { get; set; }
    public OrderStatus Status { get; set; }

    public override string ToString()
    {
        return $"Order {Id} - {Moment} - {Status}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order{
            Id = 4778,
            Moment = DateTime.Now,
            Status = OrderStatus.PendingPayment
        };

        Console.WriteLine(order);

        string txt = OrderStatus.PendingPayment.ToString(); // por padrão meu pending payment vale 0.
        Console.WriteLine(txt);

        OrderStatus os = Enum.Parse<OrderStatus>("Delivered");
        Console.WriteLine(os); // 3
    }
}