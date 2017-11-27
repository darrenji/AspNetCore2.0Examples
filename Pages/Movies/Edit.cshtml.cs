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
    public class EditModel : PageModel
    {
        private readonly IMovieService service;
        public EditModel(IMovieService service)
        {
            this.service = service;
        }

        [BindProperty]
        public MovieInputModel Movie { get; set; }

        public IActionResult OnGet(int id)
        {
            var model = this.service.GetMovie(id);
            if(model==null)
            {
                return RedirectToPage("./Index");
            }

            this.Movie = new MovieInputModel
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Summary = model.Summary
            };

            return Page();
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

            service.UpdateMove(model);
            return RedirectToPage("./Index");
        }
    }
}