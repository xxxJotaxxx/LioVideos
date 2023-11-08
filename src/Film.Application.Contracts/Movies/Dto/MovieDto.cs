using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Film.Movies.Dto
{
    public class MovieDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? Description { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }
        public string? Logo { get; set; }
        public string? Url { get; set; }
    }
}
