namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FindEvenNumbers();
            GetItemsThatStartWithLetterA();

            GroupByExample();
            GroupByWithSelect();
        }

        #region LinqExamples

        public static int[] FindEvenNumbers()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //With lambda
            var evenNumbers = numbers.Where(number => number % 2 == 0).ToArray();

            //With hand written method
            var anotherWayWithMethod = numbers.Where(IsNumberEven).ToArray();

            //What the code does behind the scenes
            BehindTheScenesNumbers(numbers);

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
            //what this does actually
            var evenNumberso = numbers.Where(number => number % 2 == 0).ToArray();

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

            var anotherWay = strings.Where(s => s != null && s.StartsWith("A"))
             .ToList();

            // LINQ example that uses hand written method
            var filteredStrings = strings.Where(IsNotNullAndStartsWithA).ToList();

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
            //What this does actually
            //   var anotherWay = strings.Where(s => s != null && s.StartsWith("A"))
            // .ToList();

            List<string> result = new();

            if (strings != null)
            {
                foreach (var s in strings)
                {
                    if (IsNotNullAndStartsWithA(s))
                    {
                        result.Add(s);
                    }
                }
            }
            else
            {
                result = new List<string>();
            }

            return result;
        }


        /// <summary>
        /// Function that cheks if the given string starts with letter A
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsNotNullAndStartsWithA(string s)
        {
            return s != null && s.StartsWith("A");
        }

        #endregion


        #region SelectAndGroupByLinqExamples

        /// <summary>
        /// This method demonstrates the use of the Select method
        /// </summary>
        private static void SelectExample1()
        {
            Console.WriteLine("SelectExample1");

            List<Movie> movies = Movie.GetMovies();

            //Selects the title of each movie (only the string Title property)
            List<string> movieTitles = movies.Select(movie => movie.Title).ToList();

            var test = movies.Select(SelectLambdaMethodBehindTheScenes);

            foreach (var title in movieTitles)
            {
                Console.WriteLine(title);
            }

        }

        private static List<string> BehindTheScenesSelect(List<Movie> movies) 
        {
            List<string> results = new List<string>();

            foreach (var movie in movies)
            {
                results.Add(movie.Title);
            }

            return results;

        }

        private static string SelectLambdaMethodBehindTheScenes(Movie movie)
        {
            return movie.Title;
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

            //We can't run this code because we don't have the AnonymousType class
            List<AnonymousType> anonymousType = new();

            foreach (var movie in movies)
            {
                anonymousType.Add(new AnonymousType { Title = movie.Title, Year = movie.Year });
            }

            foreach (var movie in anonymousType)
            {
                Console.WriteLine(movie.Title + " " + movie.Year);
            }

        }

        



        /// <summary>
        /// This method demonstrates the use of GroupBy method
        /// </summary>
        private static void GroupByExample()
        {
            Console.WriteLine("GroupByExample");

            var movies = Movie.GetMovies();

            //Groups the movies by the director
            IEnumerable<IGrouping<string, Movie>> moviesByDirector = movies.GroupBy(movie => movie.Director);

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