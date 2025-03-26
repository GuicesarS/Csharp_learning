class OutsourcedEmployee : Employee // TERCEIRIZADO "É UM" FUNCIONÁRIO TAMBÉM
{
    public double AdditionalCharge { get; set; }
    
    public OutsourcedEmployee(string name, int hours, double valuePerHour, double additionalcharge)
    : base(name, hours, valuePerHour)
    {
        AdditionalCharge = additionalcharge;
    }
    
    public override double Payment() // Reaproveitando o Payment para uma tratativa diferente.
    {
        return base.Payment() + 1.1 * AdditionalCharge;
    }
}