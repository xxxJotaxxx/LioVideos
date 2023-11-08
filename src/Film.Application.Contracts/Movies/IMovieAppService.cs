using Film.Filter;
using Film.Movies.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Film.Movies
{
    public interface IMovieAppService : ICrudAppService<MovieDto, Guid, PagedAndSortedAndFilterResultRequestDto, CreateUpdateMovieDto, CreateUpdateMovieDto>
    {

    }
}
