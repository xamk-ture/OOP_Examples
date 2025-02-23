﻿namespace LinqExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleDemo();
            GroupByExample();

            FindEvenNumbers();
            GetItemsThatStartWithLetterA();

            GroupByWithSelect();
        }

        #region LinqExamples

        public static int[] FindEvenNumbers()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<string> testNames = new List<string>();
            testNames.Add("Tuomas");
            testNames.Add("Matti");

            List<string> result1 = testNames.Where(name => name == "Tuomas").ToList();
            List<string> result2 = testNames.Where(name => name.StartsWith("T")).ToList();

            //With lambda
            var evenNumbers = numbers.Where(number => number % 2 == 0).ToArray();

            //With hand written method
            var anotherWayWithMethod = numbers.Where(IsNumberEven).ToArray();

            //What the code does behind the scenes
            BehindTheScenesNumbers(numbers);

            string test = "tesr";

            //Example with delegate
            Func<int, bool> func = IsNumberEven;

            //Example with lambda
            Func<int, bool> func2 = x => x > 5;

            var result = OwnWhereMethod(numbers, func);

            var evenWithDelegate = numbers.Where(func).ToArray();

            var evenWithLambda = numbers.Where(func2).ToArray();

            return evenNumbers;
        }

        public static List<int> OwnWhereMethod(int[] numbers, Func<int, bool> func)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers) 
            { 
                if (func(number))
                {
                    result.Add(number); 
                } 
            }

            return result;
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

            List<int> result = new();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                    result.Add(number);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Hand written method to check if the given number is even
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsNumberEven(int number)
        {
            bool result = number % 2 == 0;

            return result;
        }

        #endregion


        #region LinqExamples2
        public static List<string> GetItemsThatStartWithLetterA()
        {

            string test = null;

            string? nullTest = null;

            IEnumerable<string> strings = new List<string> { "Apple", "Banana", "Avocado", null, "Apricot" };

            var anotherWay = strings.Where(s => s != null && s.StartsWith("A")).ToList();
            

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

            if(strings == null)
                return result;

            foreach (var s in strings)
            {
                if (s != null && IsNotNullAndStartsWithA(s))
                {
                    result.Add(s);
                }
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


        public class User
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }
        }


        /// <summary>
        /// This method demonstrates the use of the Select method
        /// </summary>
        private static void SelectExample1()
        {
            Console.WriteLine("SelectExample1");

            List<Movie> movies = Movie.GetMovies();

            List<User> users = new List<User>();

            //Selects the title of each movie (only the string Title property)
            List<string> movieTitles = movies.Select(movie => movie.Title).ToList();

            List<string> movieDescriptions = movies.Select(x => x.Description).ToList();

            //above code does this behind the scenes
            List<string> titles = new();
            foreach (var movie in movies)
            {
                titles.Add(movie.Title);
            }

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

            List<User> users = new List<User>();

            //Selects the title and year of each movie and creates a new anonymous type object
            var anonymousType = movies.Select(movie => new { movie.Title, movie.Year, movie.Description });

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

            List<Movie> movies = Movie.GetMovies();

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
            List<Movie> movies = Movie.GetMovies();

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

        private static void SingleDemo()
        {
            var movies = Movie.GetMovies();

            movies.Add(new Movie() { Title = "Batmans" });

            //This will crash if there is not Movie called Batman
            //because it assumes always to find one movie called batman
            Movie movieFound = movies.Single(x => x.Title == "Batman");

            //This will return null if nothing is found and wont crash
            //but will crashif more than one movie is found
            Movie? movieMaybeFound = movies.SingleOrDefault(x => x.Title == "Batman");

            //This will return first element it finds but will crash if nothing is found
            //it assumes at least one should be found
            Movie firstMovie = movies.First(x => x.Title == "Batman");

            //This will return null if nothing is found
            Movie? firstMovieDefault = movies.FirstOrDefault(x => x.Title == "Batman");
        }


        public static void ToDictionaryDemo()
        {
            List<DictionaryUser> users = new List<DictionaryUser>();
            users.Add(new DictionaryUser(1, "Test", "email", "Address"));
            users.Add(new DictionaryUser(2, "Another ", "email FF", "Address FF"));
            users.Add(new DictionaryUser(3, "Thrid", "email SS", "Address SS"));

        
            //How to select from collection key and value and convert the result to dictionary
            Dictionary<int, string> toDictionaryExamples = users.ToDictionary(user => user.Id, user => user.Name);

            //ToDictionary does this under the hood
            Dictionary<int, string> userDictionary = new();

            foreach (var user in users)
            {
                userDictionary.Add(user.Id, user.Name);
            }
        }
    }
}