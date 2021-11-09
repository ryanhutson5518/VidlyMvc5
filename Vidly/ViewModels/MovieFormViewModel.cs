using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        // Add movie constructor
        public MovieFormViewModel()
        {
            Movie.Id = 0;
        }

        // Edit movie constructor
        public MovieFormViewModel(Movie movie)
        {
            Movie.Id = movie.Id;
            Movie.Name = movie.Name;
            Movie.GenreId = movie.GenreId;
        }

        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Movie.Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}
