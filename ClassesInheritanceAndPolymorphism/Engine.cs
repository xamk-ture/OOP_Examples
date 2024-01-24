using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesInheritanceAndPolymorphism
{

    /// <summary>
    /// Represents an engine with type and horsepower properties, and start/stop functionality.
    /// </summary>
    public class Engine : IMechanical
    {
        /// <summary>
        /// Gets or sets the type of the engine.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the horsepower of the engine.
        /// </summary>
        public int Horsepower { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class with the specified type and horsepower.
        /// </summary>
        /// <param name="type">The type of the engine.</param>
        /// <param name="horsepower">The horsepower of the engine.</param>
        public Engine(string type, int horsepower)
        {
            Type = type;
            Horsepower = horsepower;

            Console.WriteLine("Constructing Engine");
        }

        /// <summary>
        /// Prints the details of the engine to the console.
        /// </summary>
        public void PrintDetails()
        {
            Console.WriteLine($"Engine class Method call: Engine Type: {Type}, Horsepower: {Horsepower}");
        }

        /// <summary>
        /// Starts the engine.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Engine started.");
        }

        /// <summary>
        /// Stops the engine.
        /// </summary>
        public void Stop()
        {
            Console.WriteLine("Engine stopped.");
        }

        /// <summary>
        /// Displays information about the engine, including type and horsepower.
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Engine Interface method call: Type: {Type}, Horsepower: {Horsepower}");
        }
    }

}
