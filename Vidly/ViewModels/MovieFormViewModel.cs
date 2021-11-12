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
            Id = 0;
        }

        // Edit movie constructor
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
        }

        public IEnumerable<Genre> Genres { get; set; }

        // Movie properties
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}
