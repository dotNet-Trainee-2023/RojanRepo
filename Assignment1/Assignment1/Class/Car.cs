
using Assignment1.Assignment1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Assignment1.Class
{
    public class Car : Vehicle, IGPS, IFuelEfficiency
    {
        public bool IsRunning { get; private set; }

        public Car(string make, string model)
        {
            Make = make;
            Model = model;
        }

        public override void Start()
        {
            IsRunning = true;
            Console.WriteLine($"{Make} {Model} is now running.");
        }

        public override void Stop()
        {
            IsRunning = false;
            Console.WriteLine($"{Make} {Model} has stopped.");
        }

        public string GetLocation()
        {
            return "GPS coordinates: 123.456, 789.012";
        }

        public double GetMilesPerGallon()
        {
            return 30.0; // Example fuel efficiency
        }
    }
}
