using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesInheritanceAndPolymorphism
{

    /// <summary>
    /// Represents a vehicle with a manufacturer, model, and an associated engine.
    /// </summary>
    public class Vehicle : Engine, IMechanical
    {
        /// <summary>
        /// Gets or sets the manufacturer of the vehicle.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class with the specified make, model, engine type, and horsepower.
        /// </summary>
        /// <param name="make">The manufacturer of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="type">The type of the engine.</param>
        /// <param name="horsepower">The horsepower of the engine.</param>
        public Vehicle(string make, string model, string type, int horsepower)
            : base(type, horsepower)
        {
            Manufacturer = make;
            Model = model;

            Console.WriteLine("Constructing Vehicle");
        }

        /// <summary>
        /// Prints the make and model of the vehicle along with engine details.
        /// </summary>
        public void PrintVehicleDetails()
        {
            Console.WriteLine($"Make: {Manufacturer}, Model: {Model}");

            PrintDetails();
        }

        /// <summary>
        /// Displays information about the vehicle, including make, model, and engine type.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Make: {Manufacturer}, Model: {Model}, Engine Type: {Type}");
        }
    }
}
