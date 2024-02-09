using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScopeExamples
{
    internal class Program
    {
        string globalString = "I am a global string";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public void LocalScopeExample()
        {
            int localNumber = 5;
            Console.WriteLine(localNumber);

            for (int number = 0; number < 10; number++)
            {
                Console.WriteLine(number);
            }

            //This will not work because number is not in scope and cannot be accessed
            //Console.WriteLine(number);
        }

        public void ScopeTests()
        {
            //This will not work because localNumber is not in scope and cannot be accessed
            //Console.WriteLine(localNumber);

            //This will work because globalString is in scope and can be accessed
            Console.WriteLine(globalString);

            //We can create a new instance of GlobalScope because it's scope is global/public
            GlobalScope globalScope = new();

            Console.WriteLine(globalScope.GlobalString);

            //This will not work because privateString is not in scope and cannot be accessed
            //Console.WriteLine(globalScope.privateString);

        }

    }
}