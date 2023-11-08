using Film.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Film.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FilmController : AbpControllerBase
{
    protected FilmController()
    {
        LocalizationResource = typeof(FilmResource);
    }
}
