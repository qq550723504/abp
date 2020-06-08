using System;
using Volo.Abp.IdentityServer.EntityFrameworkCore;

namespace Volo.Abp.IdentityServer
{
    public class AbpIdentityServerApplicationTestBase : AbpIdentityServerTestBase<AbpIdentityServerApplicationTestModule>
    {
        protected virtual void UsingDbContext(Action<IdentityServerDbContext> action)
        {
            using var dbContext = GetRequiredService<IdentityServerDbContext>();
            action.Invoke(dbContext);
        }

        protected virtual T UsingDbContext<T>(Func<IdentityServerDbContext, T> action)
        {
            using var dbContext = GetRequiredService<IdentityServerDbContext>();
            return action.Invoke(dbContext);
        }
    }
}
