using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Film.Movies;
using Film.Movies.Dto;
using System.Threading.Tasks;

namespace Film.Web.Pages.Movies
{
    public class CreateModalModel : FilmPageModel
    {
        [BindProperty]
        public CreateUpdateMovieDto Movie { get; set; }

        private readonly IMovieAppService _movieAppService;

        public CreateModalModel(IMovieAppService webAppService)
        {
            _movieAppService = webAppService;
        }

        public void OnGet()
        {
            Movie = new CreateUpdateMovieDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _movieAppService.CreateAsync(Movie);
            return NoContent();
        }

    }
}
