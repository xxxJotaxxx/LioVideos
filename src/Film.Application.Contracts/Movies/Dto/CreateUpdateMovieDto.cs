using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Film.Movies.Dto
{
    public class CreateUpdateMovieDto
    {
        public string? Logo { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(1900, 2023, ErrorMessage = "El año debe ser mayor que 1900 y menor o igual a 2023")]
        public int Year { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? Description { get; set; }
        [Range(0, 10, ErrorMessage = "el Rating va entre 0 y 10")]
        public int Rating { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "La duración debe ser mayor que 0.")]
        public int Duration { get; set; }
        public string? Url { get; set; }
    }
}
