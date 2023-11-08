using System.Threading.Tasks;
using Film.Localization;
using Film.MultiTenancy;
using Film.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Film.Web.Menus;

public class FilmMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<FilmResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                FilmMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        //Movies
        context.Menu.Items.Insert(1, new ApplicationMenuItem(
           name: FilmMenus.Movies,
           displayName: l["Movies"],
           url: "~/" + FilmMenus.Movies,
           icon: "fas fa-house-user",
           order: 1,
           requiredPermissionName: FilmPermissions.Movie.Ver)
        );


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        return Task.CompletedTask;
    }
}
