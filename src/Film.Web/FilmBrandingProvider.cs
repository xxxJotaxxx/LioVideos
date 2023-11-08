using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Film.Web;

[Dependency(ReplaceServices = true)]
public class FilmBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "IO Videos";
    public override string LogoUrl => "/images/logo/liovideosLogo.png";
    public override string LogoReverseUrl => "/images/logo/liovideosLogo.png";

}
