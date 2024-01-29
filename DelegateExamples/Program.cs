namespace DelegateExamples
{
    internal class Program
    {
        /// <summary>
        /// Delegate that takes an int and returns an int
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public delegate int Operation(int x);

        static void Main(string[] args)
        {
            //Create new delegate instances and assign them to methods
            Operation op1 = Double;
            Operation op2 = Triple;

            int result1 = op1(4); // result1 is 8
            int result2 = op2(4); // result2 is 12

            Console.WriteLine($"Delegate 1 result {result1}");

            Console.WriteLine($"Delegate 1 result {result2}");
        }


        static int Double(int x)
        {
            return x * 2;
        }

        static int Triple(int x)
        {
            return x * 3;
        }
    }
}