using Film.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Film.Permissions;

public class FilmPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FilmPermissions.GroupName);

        // Paginas
        var GroupName = context.AddGroup(FilmPermissions.Paginas, L("Paginas"));

        // Seccion Movies
        var personas = GroupName.AddPermission(FilmPermissions.Movie.Default, L("Movies"));
        personas.AddChild(FilmPermissions.Movie.Create, L("Create"));
        personas.AddChild(FilmPermissions.Movie.Update, L("Update"));
        personas.AddChild(FilmPermissions.Movie.Delete, L("Delete"));
        personas.AddChild(FilmPermissions.Movie.Ver, L("Ver"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FilmResource>(name);
    }
}
