using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    internal class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }

        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();

            movies.Add(new Movie { Title = "The Shawshank Redemption", Year = 1994, Director = "Frank Darabont", Description = "Two imprisoned" });
            movies.Add(new Movie { Title = "The Godfather", Year = 1972, Director = "Francis Ford Coppola", Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." });
            movies.Add(new Movie { Title = "The Godfather: Part II", Year = 1974, Director = "Francis Ford Coppola", Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate." });
            movies.Add(new Movie { Title = "The Dark Knight", Year = 2008, Director = "Christopher Nolan", Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham." });

            return movies;

        }

    }
}
