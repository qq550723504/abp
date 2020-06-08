using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Clients.Dtos;

namespace Volo.Abp.IdentityServer
{
    [RemoteService(Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
    [Area("identity-server")]
    [ControllerName("Client")]
    [Route("api/identity-server/clients")]
    public class ClientsController : AbpController, IClientAppService
    {
        protected IClientAppService ClientAppService;
        public ClientsController(IClientAppService clientAppService) 
        {
            ClientAppService = clientAppService;
        }

        [HttpPost]
        public virtual async Task<ClientDto> CreateAsync(ClientDto input)
        {
            return await ClientAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task DeleteAsync(Guid id)
        {
            await ClientAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<ClientDto> GetAsync(Guid id)
        {
            return await ClientAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual async Task<PagedResultDto<ClientDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await ClientAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<ClientDto> UpdateAsync(Guid id, ClientDto input)
        {
            return await ClientAppService.UpdateAsync(id,input);
        }
    }
}
