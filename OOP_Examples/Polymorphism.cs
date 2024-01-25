using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Examples
{
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a shape.");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a square.");
        }

        public void Test()
        {
            // Usage:
            Shape shape = new Circle();
            shape.Draw(); // "Drawing a circle."

            shape = new Square();
            shape.Draw(); // "Drawing a square."
        }
    }
}
