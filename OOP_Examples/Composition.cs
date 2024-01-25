using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Examples
{
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine started.");
        }
    }

    public class Car
    {
        private Engine engine; // Composition

        public Car()
        {
            engine = new Engine();
        }

        public void StartEngine()
        {
            engine.Start();
        }
    }

    // Usage:
    //Car car = new Car();
    //car.StartEngine(); // Delegates to Engine's Start method
}
