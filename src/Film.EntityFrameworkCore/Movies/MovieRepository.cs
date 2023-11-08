using Film.EntityFrameworkCore;
using Film.Films;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;


namespace Film.Movies
{
    public class MovieRepository : EfCoreRepository<FilmDbContext, Movie, Guid>, IMovieRepository
    {
        public MovieRepository(IDbContextProvider<FilmDbContext> dbContextProvider) : base(dbContextProvider) { }

        public async Task<List<Movie>> GetListAsync(int skipCount, int maxResultCount, string sorting, Guid CreatorId, string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    x => x.Title.Contains(filter) || x.Year.ToString().Contains(filter) || x.Genre.Contains(filter) || // Filter
                    x.Director.Contains(filter) || x.Description.Contains(filter) || x.Rating.ToString().Contains(filter) || x.Duration.ToString().Contains(filter) // Filter
                )
                //.Where(x => x.CreatorId == CreatorId) //filter by CreatorId
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
