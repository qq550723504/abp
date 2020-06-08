using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.UI.Navigation;

namespace Volo.Abp.IdentityServer.Web.Navigation
{
    public class AbpIdentityServerWebMainMenuContributor : IMenuContributor
    {
        public virtual async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name != StandardMenus.Main)
            {
                return;
            }

            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

            var hasApiResourcePermission = await authorizationService.IsGrantedAsync(IdentityServerPermissions.ApiResources.Default);
            var hasClientPermission = await authorizationService.IsGrantedAsync(IdentityServerPermissions.Clients.Default);
            var hasIdentityResourcePermission = await authorizationService.IsGrantedAsync(IdentityServerPermissions.IdentityResources.Default);

            if (hasApiResourcePermission || hasClientPermission|| hasIdentityResourcePermission)
            {
                var administrationMenu = context.Menu.GetAdministration();


                var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpIdentityServerResource>>();

                var identityServerMenuItem = new ApplicationMenuItem(IdentityServerMenuNames.GroupName, l["Menu:IdentityServerManagement"], icon: "fa fa-id-card-o");
                administrationMenu.AddItem(identityServerMenuItem);

                if (hasApiResourcePermission)
                {
                    identityServerMenuItem.AddItem(new ApplicationMenuItem(IdentityServerMenuNames.ApiResources, l["ApiResources"], url: "/IdentityServer/ApiResources"));
                }

                if (hasClientPermission)
                {
                    identityServerMenuItem.AddItem(new ApplicationMenuItem(IdentityServerMenuNames.Clients, l["Clients"], url: "/IdentityServer/Clients"));
                }

                if (hasClientPermission)
                {
                    identityServerMenuItem.AddItem(new ApplicationMenuItem(IdentityServerMenuNames.IdentityResources, l["IdentityResources"], url: "/IdentityServer/IdentityResources"));
                }
            }
        }
    }
}
