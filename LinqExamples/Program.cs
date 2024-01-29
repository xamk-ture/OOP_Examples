using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FindEvenNumbers();
            GetItemsThatStartWithLetterA();
        }

        #region LinqExamples

        public static int[] FindEvenNumbers()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();

            //What the code does behind the scenes
            BehindTheScenesNumbers(numbers);

            //With hand written method
            var anotherWayWithMethod = numbers.Where(IsNumberEven).ToArray();

            return evenNumbers;
        }

        /// <summary>
        /// What linq query does behind the scenes
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static int[] BehindTheScenesNumbers(int[] numbers)
        {
            List<int> evenNumbers = new();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                    evenNumbers.Add(number);
            }

            return evenNumbers.ToArray();
        }

        /// <summary>
        /// Hand written method to check if the given number is even
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsNumberEven(int number)
        {
            return number % 2 == 0;
        }

        #endregion


        #region LinqExamples2
        public static List<string> GetItemsThatStartWithLetterA()
        {
            IEnumerable<string> strings = new List<string> { "Apple", "Banana", "Avocado", null, "Apricot" };

            // LINQ-kysely, jossa käytetään IsNotNullAndStartsWithA-funktiota
            var filteredStrings = strings?.Where(IsNotNullAndStartsWithA).ToList() ?? new List<string>();

            //What the code does behind the scenes
            BehindTheScenesString(strings);

            // Tulostetaan suodatetut merkkijonot
            foreach (var str in filteredStrings)
            {
                Console.WriteLine(str);
            }

            return filteredStrings;
        }


        /// <summary>
        /// What linq query does behind the scenes
        /// </summary>
        /// <param name="strings"></param>
        private static List<string> BehindTheScenesString(IEnumerable<string> strings)
        {
            List<string> filteredStrings2 = new();

            if (strings != null)
            {
                foreach (var s in strings)
                {
                    if (IsNotNullAndStartsWithA(s))
                    {
                        filteredStrings2.Add(s);
                    }
                }
            }
            else
            {
                filteredStrings2 = new List<string>();
            }

            return filteredStrings2;
        }


        /// <summary>
        /// Function that cheks if the given string starts with letter A
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsNotNullAndStartsWithA(string s)
        {
            return s != null && s.StartsWith("A", StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}