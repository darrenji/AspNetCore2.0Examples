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
    public class IndexModel : PageModel
    {
        private readonly IMovieService service;

        public IndexModel(IMovieService service)
        {
            this.service = service;
        }

        public List<MovieOutputModel> Movies { get; set; }

        public void OnGet()
        {
            this.Movies = this.service.GetMovies()
                .Select(t => new MovieOutputModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    ReleaseYear = t.ReleaseYear,
                    Summary = t.Summary,
                    LastReadAt = DateTime.Now
                })
                .ToList();
        }

        public IActionResult OnGetDelete1(int id)
        {
            if (!service.MovieExists(id))
                return RedirectToPage("./Index");

            service.DeleteMovie(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDelete2(int id)
        {
            if (!service.MovieExists(id))
                return RedirectToPage("./Index");

            service.DeleteMovie(id);
            return RedirectToPage("./Index");
        }
    }
}