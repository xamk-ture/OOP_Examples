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

        public virtual double Area()
        {
            return 0;
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }

        public override double Area()
        {
            return Math.PI * 5 * 5;
        }
    }

    public class Square : Shape
    {
        //public override void Draw()
        //{
        //    Console.WriteLine("Drawing a square.");
        //}

        public override double Area()
        {
            return 5 * 5;
        }
      
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle.");
        }

        public override double Area()
        {
            return 0.5 * 5 * 5;
        }
    }
}
