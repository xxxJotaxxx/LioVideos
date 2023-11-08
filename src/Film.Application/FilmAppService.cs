using System;
using System.Collections.Generic;
using System.Text;
using Film.Localization;
using Volo.Abp.Application.Services;

namespace Film;

/* Inherit your application services from this class.
 */
public abstract class FilmAppService : ApplicationService
{
    protected FilmAppService()
    {
        LocalizationResource = typeof(FilmResource);
    }
}
