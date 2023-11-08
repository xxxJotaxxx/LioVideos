using Film.Films;
using Film.Filter;
using Film.Movies.Dto;
using Film.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Film.Movies
{
    [Authorize]
    public class MovieAppService : CrudAppService<Movie, MovieDto, Guid, PagedAndSortedAndFilterResultRequestDto, CreateUpdateMovieDto, CreateUpdateMovieDto>, IMovieAppService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICurrentUser _currentUser;

        public MovieAppService(IMovieRepository movieRepository, ICurrentUser currentUser) : base(movieRepository)
        {
            _movieRepository = movieRepository;
            _currentUser = currentUser;
        }


        [Authorize(FilmPermissions.Movie.Ver)]
        public override async Task<PagedResultDto<MovieDto>> GetListAsync(PagedAndSortedAndFilterResultRequestDto input)
        {
            var moviesPaged = await _movieRepository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting, _currentUser.Id.Value, input.Filter);
            var result = ObjectMapper.Map<List<Movie>, List<MovieDto>>(moviesPaged.ToList());

            var movies = await _movieRepository.GetQueryableAsync();
            var totalCount = movies.Count();

            return new PagedResultDto<MovieDto>(
                totalCount,
                result
            );
        }

    }
}
