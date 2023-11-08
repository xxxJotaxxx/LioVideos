using AutoMapper;
using Film.Films;
using Film.Movies.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Movies
{
    public class MovieMapProfile : Profile
    {
        public MovieMapProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<CreateUpdateMovieDto, Movie>().ReverseMap();
            CreateMap<CreateUpdateMovieDto, MovieDto>().ReverseMap();
        }
    }
}
