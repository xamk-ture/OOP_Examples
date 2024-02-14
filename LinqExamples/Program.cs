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

            //Example with delegate
            Func<int, bool> func = IsNumberEven;

            //Example with lambda
            Func<int, bool> func2 = x => x % 2 == 0;

            var evenWithDelegate = numbers.Where(func).ToArray();

            var evenWithLambda = numbers.Where(func2).ToArray();

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

            // LINQ example that uses hand written method
            var filteredStrings = strings.Where(IsNotNullAndStartsWithA).ToList();

            var anotherWay = strings.Where(s => s != null && s.StartsWith("A"))
                .ToList();

            //with delegate
            Func<string, bool> func = IsNotNullAndStartsWithA;

            var delegateWay = strings.Where(func).ToList();

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


        #region SelectAndGroupByLinqExamples

        /// <summary>
        /// This method demonstrates the use of the Select method
        /// </summary>
        private static void SelectExample1()
        {
            Console.WriteLine("SelectExample1");

            var movies = Movie.GetMovies();

            //Selects the title of each movie (only the string Title property)
            var movieTitles = movies.Select(movie => movie.Title);

            foreach (var title in movieTitles)
            {
                Console.WriteLine(title);
            }

        }

        /// <summary>
        /// This method demonstrates the use of the Select method with an anonymous type
        /// </summary>
        private static void SelectExample2()
        {
            Console.WriteLine("SelectExample2");

            var movies = Movie.GetMovies();

            //Selects the title and year of each movie and creates a new anonymous type object
            var anonymousType = movies.Select(movie => new { movie.Title, movie.Year });

            foreach (var movie in anonymousType)
            {
                Console.WriteLine(movie.Title + " " + movie.Year);
            }
        }

        /// <summary>
        /// Example of what linq query does behind the scenes
        /// </summary>
        private static void SelectExample2BehindTheScenes()
        { 
            var movies = Movie.GetMovies();

            //List<AnonymousType> anonymousType = new();

            //foreach (var movie in movies)
            //{
            //    anonymousType.Add(new AnonymousType { Title = movie.Title, Year = movie.Year });
            //}

            //foreach (var movie in anonymousType)
            //{
            //    Console.WriteLine(movie.Title + " " + movie.Year);
            //}

        }

        /// <summary>
        /// This method demonstrates the use of GroupBy method
        /// </summary>
        private static void GroupByExample()
        {
            Console.WriteLine("GroupByExample");

            var movies = Movie.GetMovies();

            //Groups the movies by the director
            var moviesByDirector = movies.GroupBy(movie => movie.Director);

            foreach (var group in moviesByDirector)
            {
                //The key is the director
                Console.WriteLine(group.Key);

                //The group is the list of movies by that director
                foreach (var movie in group)
                {
                    Console.WriteLine(movie.Title);
                }
            }
        }

        /// <summary>
        /// Example of what linq query does behind the scenes
        /// </summary>
        private static void GroupByExampleBehindTheScenes()
        {
            var movies = Movie.GetMovies();

            Dictionary<string, List<Movie>> moviesByDirector = new();

            foreach (var movie in movies)
            {
                if (moviesByDirector.ContainsKey(movie.Director))
                {
                    moviesByDirector[movie.Director].Add(movie);
                }
                else
                {
                    moviesByDirector.Add(movie.Director, new List<Movie> { movie });
                }
            }

            foreach (var group in moviesByDirector)
            {
                Console.WriteLine(group.Key);

                foreach (var movie in group.Value)
                {
                    Console.WriteLine(movie.Title);
                }
            }

        }

        private static void GroupByWithSelect()
        {
            Console.WriteLine("GroupByWithSelect");

            var movies = Movie.GetMovies();

            //Groups the movies by the director and selects the title of each movie
            var moviesByDirector = movies.GroupBy(movie => movie.Director, movie => movie.Title);

            foreach (var group in moviesByDirector)
            {
                //The key is the director
                Console.WriteLine(group.Key);

                //The group is the list of movie titles by that director
                foreach (var title in group)
                {
                    Console.WriteLine(title);
                }
            }
        }

        private static void GroupByWithSelectBehindTheScenes()
        {
            var movies = Movie.GetMovies();

            Dictionary<string, List<string>> moviesByDirector = new();

            foreach (var movie in movies)
            {
                if (moviesByDirector.ContainsKey(movie.Director))
                {
                    moviesByDirector[movie.Director].Add(movie.Title);
                }
                else
                {
                    moviesByDirector.Add(movie.Director, new List<string> { movie.Title });
                }
            }

            foreach (var group in moviesByDirector)
            {
                Console.WriteLine(group.Key);

                foreach (var title in group.Value)
                {
                    Console.WriteLine(title);
                }
            }

        }

        #endregion
    }
}