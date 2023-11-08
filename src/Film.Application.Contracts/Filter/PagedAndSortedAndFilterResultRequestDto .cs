using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Film.Filter
{
    public class PagedAndSortedAndFilterResultRequestDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }  
    }
}
