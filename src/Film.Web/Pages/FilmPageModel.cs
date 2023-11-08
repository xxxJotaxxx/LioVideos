using Film.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Film.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class FilmPageModel : AbpPageModel
{
    protected FilmPageModel()
    {
        LocalizationResourceType = typeof(FilmResource);
    }
}
