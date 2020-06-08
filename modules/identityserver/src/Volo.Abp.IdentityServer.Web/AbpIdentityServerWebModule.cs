using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.IdentityServer.Web.Navigation;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.IdentityServer.Web
{
    [DependsOn(
        typeof(AbpIdentityServerHttpApiModule),
        typeof(AbpAspNetCoreMvcUiBootstrapModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpPermissionManagementWebModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule)
        )]
    public class AbpIdentityServerWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(AbpIdentityServerResource), typeof(AbpIdentityServerWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpIdentityServerWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AbpIdentityServerWebMainMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIdentityServerWebModule>("Volo.Abp.IdentityServer.Web");
            });

            context.Services.AddAutoMapperObjectMapper<AbpIdentityServerWebModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpIdentityServerWebAutoMapperProfile>();
            });

            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AuthorizePage("/IdentityServer/ApiResources/Index", IdentityServerPermissions.ApiResources.Default);
                options.Conventions.AuthorizePage("/IdentityServer/ApiResources/CreateModal", IdentityServerPermissions.ApiResources.Create);
                options.Conventions.AuthorizePage("/IdentityServer/ApiResources/EditModal", IdentityServerPermissions.ApiResources.Update);
                options.Conventions.AuthorizePage("/IdentityServer/Clients/Index", IdentityServerPermissions.Clients.Default);
                options.Conventions.AuthorizePage("/IdentityServer/Clients/CreateModal", IdentityServerPermissions.Clients.Create);
                options.Conventions.AuthorizePage("/IdentityServer/Clients/EditModal", IdentityServerPermissions.Clients.Update);
                options.Conventions.AuthorizePage("/IdentityServer/IdentityResources/Index", IdentityServerPermissions.IdentityResources.Default);
                options.Conventions.AuthorizePage("/IdentityServer/IdentityResources/CreateModal", IdentityServerPermissions.IdentityResources.Create);
                options.Conventions.AuthorizePage("/IdentityServer/IdentityResources/EditModal", IdentityServerPermissions.IdentityResources.Update);
            });
        }
    }
}
