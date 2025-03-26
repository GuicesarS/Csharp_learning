using System;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("How many rows will the matrix have:");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("How many columns:");
        int columns = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Enter the value for position [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.Write("Values collected!");
        Console.WriteLine();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{matrix[i, j]} \t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nEnter the value you want to find: ");
        int search = int.Parse(Console.ReadLine());
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (search == matrix[i, j])
                {
                    // Checking if there are neighbors before accessing the position
                    if (j < columns - 1)  // Right
                        Console.WriteLine($"Right: {matrix[i, j + 1]}");

                    if (j > 0)  // Left
                        Console.WriteLine($"Left: {matrix[i, j - 1]}");

                    if (i > 0)  // Up
                        Console.WriteLine($"Up: {matrix[i - 1, j]}");

                    if (i < rows - 1)  // Down
                        Console.WriteLine($"Down: {matrix[i + 1, j]}");
                }
                else
                {
                    Console.WriteLine("The value was not found!");
                }
                break;
            }
        }
    }
}
