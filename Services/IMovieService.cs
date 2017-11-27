using Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Movie GetMovie(int id);
        void AddMovie(Movie item);
        void UpdateMove(Movie item);
        void DeleteMovie(int id);
        bool MovieExists(int id);
    }
}
