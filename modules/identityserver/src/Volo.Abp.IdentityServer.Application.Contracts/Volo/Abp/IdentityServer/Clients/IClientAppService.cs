using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.Clients.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public interface IClientAppService : IApplicationService
    {
        Task<PagedResultDto<ClientDto>> GetListAsync(PagedAndSortedResultRequestDto input);

        Task<ClientDto> CreateAsync(ClientDto input);

        Task<ClientDto> GetAsync(Guid id);

        Task<ClientDto> UpdateAsync(Guid id, ClientDto input);

        Task DeleteAsync(Guid id);
    }
}
