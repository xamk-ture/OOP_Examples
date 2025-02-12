using System.Collections;

namespace CastingExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Implicit Casting
            int num = 10;
            double result = num;
            Console.WriteLine($"Implicit Casting: {result}");

            // Explicit Casting
            double value = 9.78;
            int intValue = (int)value;
            Console.WriteLine($"Explicit Casting: {intValue}");

            // Using Convert Class
            string numberString = "123";
            int convertedNumber = Convert.ToInt32(numberString);
            Console.WriteLine($"Convert Class: {convertedNumber}");

            // Using 'as' Operator
            object obj = "Hello";
            string str = obj as string;
            str = (string)obj;
            Console.WriteLine($"As Operator: {str}");

            // Using 'is' Operator
            object objNumber = 42;

            if (objNumber is int number)
            {
                Console.WriteLine($"Is Operator: {number}");
            }

            // Using Cast<> with ArrayList
            ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5 };

            List<string> strings    = new List<string>();

            IEnumerable<string> test = arrayList.Cast<string>();
            IEnumerable<int> numbers = arrayList.Cast<int>();
            Console.WriteLine("Cast<> with ArrayList:");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

            // Using Cast<> with IEnumerable<object>
            IEnumerable<object> objects = new List<object> { "Alice", "Bob", "Charlie" };
            IEnumerable<string> names = objects.Cast<string>();
            Console.WriteLine("Cast<> with IEnumerable<object>:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            // Handling Cast<> Exception
            ArrayList mixedList = new ArrayList { 1, 2, 3, "four", 5 };
            try
            {
                var filteredNumbers = mixedList.Cast<int>().Where(n => n > 2).ToList();
                Console.WriteLine("Cast<> with mixed types:");
                filteredNumbers.ForEach(Console.WriteLine);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
