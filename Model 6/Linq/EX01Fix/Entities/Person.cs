
namespace Classes
{
    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Person(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name},{Email},{Salary}";
        }

    }
}