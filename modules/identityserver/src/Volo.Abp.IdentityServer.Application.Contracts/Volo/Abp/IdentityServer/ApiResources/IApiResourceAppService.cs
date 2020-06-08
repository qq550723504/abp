using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.ApiResources.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public interface IApiResourceAppService:IApplicationService
    {
        Task<PagedResultDto<ApiResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<ApiResourceDto> CreateAsync(ApiResourceDto input);

        Task<ApiResourceDto> GetAsync(Guid id);

        Task<ApiResourceDto> UpdateAsync(Guid id, ApiResourceDto input);

        Task DeleteAsync(Guid id);
    }
}
