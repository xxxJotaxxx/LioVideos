using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Film.Data;

/* This is used if database provider does't define
 * IFilmDbSchemaMigrator implementation.
 */
public class NullFilmDbSchemaMigrator : IFilmDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
