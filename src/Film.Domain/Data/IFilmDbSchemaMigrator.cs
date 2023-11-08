using System.Threading.Tasks;

namespace Film.Data;

public interface IFilmDbSchemaMigrator
{
    Task MigrateAsync();
}
