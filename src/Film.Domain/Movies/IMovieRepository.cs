using Film.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Film.Movies
{
    public interface IMovieRepository : IRepository<Movie, Guid>
    {
        Task<List<Movie>> GetListAsync(int skipCount, int maxResultCount, string sorting, Guid CreatorId, string filter);
    }
}
