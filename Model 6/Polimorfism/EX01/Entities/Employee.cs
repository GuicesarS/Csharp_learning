class Employee
{
    public string Name { get; set; }
    public int Hours { get; set; }
    public double ValuePerHour { get; set; }

    public Employee() { }

    public Employee(string name, int hours, double valuePerHour)
    {
        Name = name;
        Hours = hours;
        ValuePerHour = valuePerHour;
    }

    public virtual double Payment() // VIRTUAL POIS HAVERÁ UM PAGAMENTO DIFERENTE PARA OS TERCEIRIZADOS
    {
        return Hours * ValuePerHour;
    }

}