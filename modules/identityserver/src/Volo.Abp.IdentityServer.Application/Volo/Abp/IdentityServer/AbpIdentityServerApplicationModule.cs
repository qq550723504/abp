using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Volo.Abp.IdentityServer
{
    [DependsOn(
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpIdentityServerApplicationContractsModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpPermissionManagementApplicationModule)
        )]
    public class AbpIdentityServerApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpIdentityServerApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AbpIdentityServerApplicationModuleAutoMapperProfile>(validate: true);
            });
        }
    }
}
