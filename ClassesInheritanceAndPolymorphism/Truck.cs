using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesInheritanceAndPolymorphism
{
    public class Truck : Vehicle
    {
        public Truck(string make, string model, string type, int horsepower)
            : base(make, model, type, horsepower) 
        {
            Console.WriteLine("Constructing Truck");
        }

        public void Tow()
        {
            Console.WriteLine("Towing...");
        }
    }
}
