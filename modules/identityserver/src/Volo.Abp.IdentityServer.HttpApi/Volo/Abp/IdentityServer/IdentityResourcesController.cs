using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.IdentityServer.IdentityResources.Dtos;

namespace Volo.Abp.IdentityServer
{
    [RemoteService(Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
    [Area("identity-server")]
    [ControllerName("IdentityResource")]
    [Route("api/identity-server/identityresources")]
    public class IdentityResourcesController : AbpController, IIdentityResourceAppService
    {
        protected IIdentityResourceAppService IdentityResourceAppService;
        public IdentityResourcesController(IIdentityResourceAppService identityResourceAppService) 
        {
            IdentityResourceAppService = identityResourceAppService;
        }

        [HttpPost]
        public virtual async Task<IdentityResourceDto> CreateAsync(IdentityResourceDto input)
        {
            return await IdentityResourceAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task DeleteAsync(Guid id)
        {
            await IdentityResourceAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IdentityResourceDto> GetAsync(Guid id)
        {
            return await IdentityResourceAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual async Task<PagedResultDto<IdentityResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await IdentityResourceAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IdentityResourceDto> UpdateAsync(Guid id, IdentityResourceDto input)
        {
            return await IdentityResourceAppService.UpdateAsync(id,input);
        }
    }
}
