using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Film.Movies.Dto;
using Film.Movies;
using System.Threading.Tasks;
using System;

namespace Film.Web.Pages.Movies
{
    public class InfoModalModel : FilmPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public MovieDto Movie { get; set; }

        private readonly IMovieAppService _movieAppService;

        public InfoModalModel(IMovieAppService personaAppService)
        {
            _movieAppService = personaAppService;
        }

        public async Task<IActionResult> OnGetAsync()
        {

            if (Id == Guid.Empty)
            {
                return NotFound();
            }

            Movie = await _movieAppService.GetAsync((Guid)Id);

            return Page();
        }

    }
}
