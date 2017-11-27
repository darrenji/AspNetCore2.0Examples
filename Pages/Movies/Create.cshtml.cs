using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Examples.Services;
using Examples.Models;

namespace Examples.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMovieService service;
        public CreateModel(IMovieService service)
        {
            this.service = service;
        }

        [BindProperty]
        public MovieInputModel Movie { get; set; }

        public void OnGet()
        {
            this.Movie = new MovieInputModel();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var model = new Movie
            {
                Id = this.Movie.Id,
                Title = this.Movie.Title,
                ReleaseYear = this.Movie.ReleaseYear,
                Summary = this.Movie.Summary
            };

            service.AddMovie(model);
            return RedirectToPage("./Index");
        }
    }
}