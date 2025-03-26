/*
Create a car rental system where the user provides their name, address, and the desired car (a number from 1 to 10).
The system should check if the chosen car has already been rented, and if it is unavailable, it should ask the user to choose another car.
After registration, display the details of all rentals. Ensure that the car number is within the range of 1 to 10.
*/

using System;

class CarRental
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (value != null && value.Length > 0) // If not null and length is greater than 0.
            {
                _name = value;
            }

            /* Option 2: if (!string.IsNullOrEmpty(value)) // "! - Not True" If not null or empty.
            {
                _clientName = value;
            }

            Option 3: if (!string.IsNullOrWhiteSpace(value)) // "! - Not True" if not null or empty or just white space " ".
            {
                _clientName = value;
            }
            */
        }
    }

    public string Address { get; private set; }
    public int DesiredCar { get; private set; }

    public CarRental(string name, string address, int desiredCar)
    {
        Name = name;
        Address = address;
        DesiredCar = desiredCar;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write($"How many cars will be rented: ");
        int quantity = int.Parse(Console.ReadLine());
        CarRental[] carsToChooseFrom = new CarRental[quantity];

        for (int i = 0; i < quantity; i++)
        {
            Console.Write($"\nEnter your name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter your address: ");
            string address = Console.ReadLine();

            int chosenCar;
            bool carAvailableForRent;

            do
            {
                Console.Write($"Select the desired car (1-10): ");
                chosenCar = int.Parse(Console.ReadLine());
                carAvailableForRent = true;

                for (int j = 0; j < i; j++)
                {
                    if (carsToChooseFrom[j] != null && carsToChooseFrom[j].DesiredCar == chosenCar)
                    {
                        Console.WriteLine("Car already chosen or incorrect data, please try again: ");
                        carAvailableForRent = false;
                        break;
                    }
                }

            } while (!carAvailableForRent); // It will keep asking while the condition is false.
            carsToChooseFrom[i] = new CarRental(name, address, chosenCar);
        }

        for (int i = 0; i < quantity; i++)
        {
            Console.WriteLine($"Name: {carsToChooseFrom[i].Name} - Address: {carsToChooseFrom[i].Address} - Chosen Car: {carsToChooseFrom[i].DesiredCar}");
        }
    }
}
