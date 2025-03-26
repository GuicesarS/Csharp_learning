using System;
using System.Globalization;

class RoomData
{
    private string _name;
    public string Name
    {
        get { return _name; }
        private set
        {
            if (value != null && value.Length > 0)  // Correct check: name cannot be null and cannot be empty
            {
                _name = value;
            }
        }
    }
    public string Email { get; private set; }
    public int ChosenRoom { get; private set; }

    public RoomData(string name, string email, int chosenRoom)
    {
        Name = name;
        Email = email;
        ChosenRoom = chosenRoom;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write($"How many rooms will be rented: ");
        int rentedRooms = int.Parse(Console.ReadLine());
        RoomData[] rooms = new RoomData[10];

        for (int i = 0; i < rentedRooms; i++)
        {
            Console.WriteLine($"General Registration");
            Console.Write($"Name: ");
            string name = Console.ReadLine();
            Console.Write($"Email: ");
            string email = Console.ReadLine();

            int choice;
            bool roomAvailable;
            
            do
            {
                Console.WriteLine("Enter the room number you want (1-10): ");
                choice = int.Parse(Console.ReadLine());
                roomAvailable = true;

                for (int j = 0; j < i; j++) // Loops until the room being registered (i)
                {
                    if (rooms[j].ChosenRoom == choice)
                    {
                        Console.Write($"Room {rooms[j].ChosenRoom} is not available. Choose another room: "); // case where I choose a room that's already filled/occupied
                        roomAvailable = false;
                        break;
                    }

                }

            } while (!roomAvailable);
            rooms[i] = new RoomData(name, email, choice);

        }

        for (int i = 0; i < rentedRooms; i++)
        {
            Console.WriteLine($"\nRoom data {rooms[i].ChosenRoom}: ");
            Console.WriteLine($"Name: {rooms[i].Name}, Email: {rooms[i].Email}");
        }
    }
}
