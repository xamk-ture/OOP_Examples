using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesInheritanceAndPolymorphism
{
    // Class Definition
    // 'public class Vehicle : Engine': Defines a new class named 'Vehicle' which inherits from the 'Engine' class.
    // Inheritance is denoted by the colon symbol (:) followed by the base class name 'Engine'.
    // This means 'Vehicle' includes all properties and methods of 'Engine', along with its own defined features.
    public class Vehicle : Engine
    {
        // Properties

        // 'public string Make { get; set; }': Defines a property named 'Make' of type 'string'.
        // This property is used to store the make of the vehicle and is accessible externally.
        // The '{ get; set; }' syntax provides automatic getters and setters.
        public string Manufacturer { get; set; }

        // 'public string Model { get; set; }': Similarly, this line defines a property named 'Model'
        // of type 'string'. It is used to store the model of the vehicle and also has getters and setters.
        public string Model { get; set; }

        // Constructor

        // 'public Vehicle(string make, string model, string type, int horsepower)': Constructor for the 'Vehicle' class.
        // It takes four parameters - 'make' and 'model' specific to 'Vehicle', and 'type' and 'horsepower'
        // which are passed to the base 'Engine' class constructor.
        public Vehicle(string make, string model, string type, int horsepower)
            : base(type, horsepower) // Calls the constructor of the base class 'Engine' with 'type' and 'horsepower'.
        {
            // Set the 'Make' and 'Model' properties with the values provided.
            Manufacturer = make;
            Model = model;

            // 'Console.WriteLine("Constructing Vehicle")': Prints "Constructing Vehicle" to the console
            // whenever a 'Vehicle' object is constructed.
            Console.WriteLine("Constructing Vehicle");
        }

        // Method

        // 'public void PrintVehicleDetails()': Method to print the details of the vehicle.
        // This method is specific to the 'Vehicle' class and complements the functionality inherited from 'Engine'.
        public void PrintVehicleDetails()
        {
            // Print the make and model of the vehicle using interpolated string syntax.
            Console.WriteLine($"Make: {Manufacturer}, Model: {Model}");
            // Call the 'PrintDetails' method from the base 'Engine' class to print engine details.
            // This demonstrates the use of inheritance, where a method from the base class is utilized.
            PrintDetails();
        }
    }
}
