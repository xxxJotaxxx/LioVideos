using Film.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Film.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FilmEntityFrameworkCoreModule),
    typeof(FilmApplicationContractsModule)
    )]
public class FilmDbMigratorModule : AbpModule
{
}
