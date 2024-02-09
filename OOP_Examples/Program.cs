namespace OOP_Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Test();
           
        }

        public static void Test()
        {
            // Usage:
            Shape shape = new Circle();
            shape.Draw(); // "Drawing a circle."
            shape.Area();

            Square square = new Square();
            square.Draw(); // "Drawing a square."
            square.Area();

            Circle circle = new Circle();   
            circle.Draw(); // "Drawing a circle."
            circle.Area();
        }
    }
}