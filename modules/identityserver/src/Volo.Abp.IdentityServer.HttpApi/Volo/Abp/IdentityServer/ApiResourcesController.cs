using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiResources.Dtos;

namespace Volo.Abp.IdentityServer
{
    [RemoteService(Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
    [Area("identity-server")]
    [ControllerName("ApiResource")]
    [Route("api/identity-server/apiresources")]
    public class ApiResourcesController : AbpController, IApiResourceAppService
    {
        protected IApiResourceAppService ApiResourceAppService { get; }

        public ApiResourcesController(IApiResourceAppService apiResourceAppService)
        {
            ApiResourceAppService = apiResourceAppService;
        }

        [HttpPost]
        public virtual async Task<ApiResourceDto> CreateAsync(ApiResourceDto input)
        {
            return await ApiResourceAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task DeleteAsync(Guid id)
        {
            await ApiResourceAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<ApiResourceDto> GetAsync(Guid id)
        {
            return await ApiResourceAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual async Task<PagedResultDto<ApiResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return await ApiResourceAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<ApiResourceDto> UpdateAsync(Guid id, ApiResourceDto input)
        {
            return await ApiResourceAppService.UpdateAsync(id, input);
        }
    }
}
