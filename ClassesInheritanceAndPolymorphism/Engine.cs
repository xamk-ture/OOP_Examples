using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesInheritanceAndPolymorphism
{
    // Class Definition
    // 'public class Engine': Defines a new class named 'Engine'.
    // The 'public' keyword specifies that this class is accessible from other parts of the program.
    public class Engine
    {
        // Properties

        // 'public string Type { get; set; }': Defines a property named 'Type' of type 'string'.
        // This property is publicly accessible and can be modified externally.
        // The '{ get; set; }' syntax provides automatic getters and setters,
        // allowing for reading and writing the value of 'Type'.
        public string Type { get; set; }

        // 'public int Horsepower { get; set; }': Similarly, this line defines a property named 'Horsepower'
        // of type 'int'. It also has getters and setters for external access and modification.
        public int Horsepower { get; set; }

        // Constructor

        // 'public Engine(string type, int horsepower)': Constructor for the 'Engine' class.
        // It is invoked when a new instance of 'Engine' is created.
        // Takes two parameters - 'type' (a 'string') and 'horsepower' (an 'int').
        public Engine(string type, int horsepower)
        {
            // Inside the constructor, initialize the 'Type' and 'Horsepower' properties
            // with the values passed through the parameters.
            Type = type;
            Horsepower = horsepower;

            // 'Console.WriteLine("Constructing Engine")': Prints the text "Constructing Engine"
            // to the console whenever an 'Engine' object is constructed.
            Console.WriteLine("Constructing Engine");
        }

        // Method

        // 'public void PrintDetails()': Method that can be called on instances of the 'Engine' class.
        // It does not return anything ('void') and is public, meaning it can be called from outside the class.
        public void PrintDetails()
        {
            // 'Console.WriteLine($"Engine Type: {Type}, Horsepower: {Horsepower}")': Within this method,
            // it prints the engine's type and horsepower to the console using interpolated string syntax.
            Console.WriteLine($"Engine Type: {Type}, Horsepower: {Horsepower}");
        }
    }


}
