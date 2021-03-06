using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Examples.Services;

namespace Examples.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly IMovieService service;

        public DeleteModel(IMovieService service)
        {
            this.service = service;
        }

        [BindProperty]
        public int Id { get; set; }
        public string Title { get; set; }

        public IActionResult OnGet(int id)
        {
            var model = this.service.GetMovie(id);
            if (model == null)
                return RedirectToPage("./Index");

            this.Id = model.Id;
            this.Title = model.Title;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!service.MovieExists(this.Id))
                return RedirectToPage("./Index");
            service.DeleteMovie(this.Id);
            return RedirectToPage("./Index");
        }
    }
}