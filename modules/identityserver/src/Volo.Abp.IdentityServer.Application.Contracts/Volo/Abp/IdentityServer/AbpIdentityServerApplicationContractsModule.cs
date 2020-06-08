using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Volo.Abp.IdentityServer
{
    [DependsOn(
        typeof(AbpIdentityServerDomainSharedModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
        )]
    public class AbpIdentityServerApplicationContractsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
