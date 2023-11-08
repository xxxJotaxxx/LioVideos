using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Film.Films
{
    public class Movie : FullAuditedAggregateRoot<Guid>
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
