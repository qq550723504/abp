using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.Localization;

namespace Volo.Abp.IdentityServer
{
    public abstract class AbpIdentityServerAppServiceBase : ApplicationService
    {
        protected AbpIdentityServerAppServiceBase() 
        {
            ObjectMapperContext = typeof(AbpIdentityServerApplicationModule);
            LocalizationResource = typeof(AbpIdentityServerResource);
        }
    }
}
