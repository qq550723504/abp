using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Volo.Abp.IdentityServer
{
    [DependsOn(
        typeof(AbpIdentityServerApplicationModule),
        typeof(AbpIdentityServerDomainTestModule)
        )]
    public class AbpIdentityServerApplicationTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}
