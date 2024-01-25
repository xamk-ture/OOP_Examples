using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Examples
{
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }
    }


    public class Dog : Animal // Dog inherits from Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking...");
        }

        public void Test()
        {
            // Usage:
            Dog dog = new Dog();
            dog.Eat(); // Inherited from Animal
            dog.Bark(); // Defined in Dog
        }
    }


}
