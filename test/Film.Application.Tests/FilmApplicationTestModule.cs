using Volo.Abp.Modularity;

namespace Film;

[DependsOn(
    typeof(FilmApplicationModule),
    typeof(FilmDomainTestModule)
    )]
public class FilmApplicationTestModule : AbpModule
{

}
