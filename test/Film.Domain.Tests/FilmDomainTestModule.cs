using Film.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Film;

[DependsOn(
    typeof(FilmEntityFrameworkCoreTestModule)
    )]
public class FilmDomainTestModule : AbpModule
{

}
