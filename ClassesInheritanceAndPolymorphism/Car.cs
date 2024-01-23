using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesInheritanceAndPolymorphism
{
    public class Car : Vehicle
    {
        public Car(string make, string model, string type, int horsepower)
            : base(make, model, type, horsepower) 
        {
            Console.WriteLine("Constructing Car");
        }

        public void Honk()
        {
            Console.WriteLine("HOONK HOOONK!");
        }
    }
}
