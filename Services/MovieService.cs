﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.Models;

namespace Examples.Services
{
    public class MovieService : IMovieService
    {
        private readonly List<Movie> movies;

        public MovieService()
        {
            this.movies = new List<Movie>
            {
                new Movie{Id=1, Title="never say never again", ReleaseYear=1983, Summary="a spcture agent has stolen two american nuclear warheads"},
                new Movie{Id=2, Title="diamonds are forever", ReleaseYear=1971, Summary="a diamond smuggling investigation"},
                new Movie{Id=3, Title="you only live twice", ReleaseYear=1967,Summary="agent 007 and the secret"}
            };
        }

        public void AddMovie(Movie item)
        {
            this.movies.Add(item);
        }

        public void DeleteMovie(int id)
        {
            var model = this.movies.Where(m => m.Id == id).FirstOrDefault();
            this.movies.Remove(model);
        }

        public Movie GetMovie(int id)
        {
            return this.movies.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Movie> GetMovies()
        {
            return this.movies.ToList();
        }

        public bool MovieExists(int id)
        {
            return this.movies.Any(t => t.Id == id);
        }

        public void UpdateMove(Movie item)
        {
            var model = this.movies.Where(t => t.Id == item.Id).FirstOrDefault();
            model.Title = item.Title;
            model.ReleaseYear = item.ReleaseYear;
            model.Summary = item.Summary;
            model.Id = item.Id;
           
        }
    }
}
