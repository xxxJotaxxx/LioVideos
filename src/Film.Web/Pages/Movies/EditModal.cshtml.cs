using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Film.Movies.Dto;
using Film.Movies;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;
using System;

namespace Film.Web.Pages.Movies
{
    public class EditModalModel : FilmPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateMovieDto Movie { get; set; }

        private readonly IMovieAppService _movieAppService;

        public EditModalModel(IMovieAppService webAppService)
        {
            _movieAppService = webAppService;
        }

        public async Task<IActionResult> OnGet()
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }

            var movie = await _movieAppService.GetAsync(Id);
            Movie = ObjectMapper.Map<MovieDto, CreateUpdateMovieDto>(movie);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _movieAppService.UpdateAsync(Id, Movie);
            return NoContent();
        }
    }
}
