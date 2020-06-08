using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.IdentityResources.Dtos;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    public interface IIdentityResourceAppService:IApplicationService
    {
        Task<PagedResultDto<IdentityResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<IdentityResourceDto> CreateAsync(IdentityResourceDto input);

        Task<IdentityResourceDto> GetAsync(Guid id);

        Task<IdentityResourceDto> UpdateAsync(Guid id, IdentityResourceDto input);

        Task DeleteAsync(Guid id);
    }
}
