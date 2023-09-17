using Assignment1.Assignment1.Class;
using Assignment1.Assignment1.Interface;


class Program
{
    static void Main(string[] args)
    {
        // Polymorphism: Create an array of Vehicles
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car("Toyota", "Camry"),
            new Car("Honda", "Civic")
        };

        foreach (var vehicle in vehicles)
        {
            vehicle.Start();
            vehicle.Stop();

            // Ternary operator and Null coalescing operator
            string location = (vehicle is IGPS gpsVehicle) ? gpsVehicle.GetLocation() : "Location not available";
            double mpg = (vehicle is IFuelEfficiency fuelEfficiency) ? fuelEfficiency.GetMilesPerGallon() : 0.0;

            Console.WriteLine($"Location: {location}");
            Console.WriteLine($"Miles Per Gallon: {mpg}");
            Console.WriteLine("-------------**************------------");
        }

        // Creating a list and performing LINQ operations
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        var sum = numbers.Sum();
        var max = numbers.Max();

        Console.WriteLine($"Even Numbers: {string.Join(", ", evenNumbers)}");
        Console.WriteLine($"Sum of Numbers: {sum}");
        Console.WriteLine($"Maximum Number: {max}");
    }
}

