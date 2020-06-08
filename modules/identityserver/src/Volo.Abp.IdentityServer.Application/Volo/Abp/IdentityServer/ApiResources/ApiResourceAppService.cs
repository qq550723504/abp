using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.ApiResources.Dtos;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.IdentityServer.ApiResources
{
    [Authorize(IdentityServerPermissions.ApiResources.Default)]
    public class ApiResourceAppService : AbpIdentityServerAppServiceBase, IApiResourceAppService
    {
        protected IApiResourceRepository ApiResourceRepository;
        public ApiResourceAppService(IApiResourceRepository apiResourceRepository)
        {
            ApiResourceRepository = apiResourceRepository;
        }

        [Authorize(IdentityServerPermissions.ApiResources.Create)]
        public virtual async Task<ApiResourceDto> CreateAsync(ApiResourceDto input)
        {
            var apiResource = new ApiResource(
                 GuidGenerator.Create(),
                 input.Name,
                 input.DisplayName
             );

            input.MapExtraPropertiesTo(apiResource);

            await ApiResourceRepository.InsertAsync(apiResource);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<ApiResource, ApiResourceDto>(apiResource);
        }

        [Authorize(IdentityServerPermissions.ApiResources.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var apiResource = await ApiResourceRepository.FindAsync(id);
            if (apiResource == null)
            {
                return;
            }

            await ApiResourceRepository.DeleteAsync(apiResource);
        }

        public virtual async Task<ApiResourceDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ApiResource, ApiResourceDto>(
                await ApiResourceRepository.FindAsync(id)
            );
        }

        public virtual async Task<PagedResultDto<ApiResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var list = await ApiResourceRepository.GetListAsync(input.Sorting,input.SkipCount, input.MaxResultCount);
            var totalCount = await ApiResourceRepository.GetCountAsync();

            return new PagedResultDto<ApiResourceDto>(
                totalCount,
                ObjectMapper.Map<List<ApiResource>, List<ApiResourceDto>>(list)
                );
        }

        [Authorize(IdentityServerPermissions.ApiResources.Update)]
        public virtual async Task<ApiResourceDto> UpdateAsync(Guid id, ApiResourceDto input)
        {
            var apiResource = await ApiResourceRepository.FindAsync(id);
            input.MapExtraPropertiesTo(apiResource);

            apiResource.Description = input.Description;
            apiResource.DisplayName = input.DisplayName;

            await ApiResourceRepository.UpdateAsync(apiResource);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<ApiResource, ApiResourceDto>(apiResource);
        }
    }
}
