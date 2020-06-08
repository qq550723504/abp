using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.IdentityResources.Dtos;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    [Authorize(IdentityServerPermissions.IdentityResources.Default)]
    public class IdentityResourceAppService : AbpIdentityServerAppServiceBase, IIdentityResourceAppService
    {
        protected IIdentityResourceRepository IdentityResourceRepository;
        public IdentityResourceAppService(IIdentityResourceRepository identityResourceRepository) 
        {
            IdentityResourceRepository = identityResourceRepository;
        }

        [Authorize(IdentityServerPermissions.IdentityResources.Create)]
        public virtual async Task<IdentityResourceDto> CreateAsync(IdentityResourceDto input)
        {
            var identityResource = new IdentityResource(
                GuidGenerator.Create(),
                input.Name,
                input.DisplayName
            );

            input.MapExtraPropertiesTo(identityResource);

            await IdentityResourceRepository.InsertAsync(identityResource);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityResource, IdentityResourceDto>(identityResource);
        }

        [Authorize(IdentityServerPermissions.IdentityResources.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var identityResource = await IdentityResourceRepository.FindAsync(id);
            if (identityResource == null)
            {
                return;
            }

            await IdentityResourceRepository.DeleteAsync(identityResource);
        }

        public virtual async Task<IdentityResourceDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<IdentityResource, IdentityResourceDto>(
                await IdentityResourceRepository.FindAsync(id)
            );
        }

        public virtual async Task<PagedResultDto<IdentityResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var list = await IdentityResourceRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);
            var totalCount = await IdentityResourceRepository.GetCountAsync();

            return new PagedResultDto<IdentityResourceDto>(
                totalCount,
                ObjectMapper.Map<List<IdentityResource>, List<IdentityResourceDto>>(list)
                );
        }

        [Authorize(IdentityServerPermissions.IdentityResources.Update)]
        public virtual async Task<IdentityResourceDto> UpdateAsync(Guid id, IdentityResourceDto input)
        {
            var identityResource = await IdentityResourceRepository.FindAsync(id);
            identityResource.ConcurrencyStamp = input.ConcurrencyStamp;

            input.MapExtraPropertiesTo(identityResource);

            await IdentityResourceRepository.UpdateAsync(identityResource);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<IdentityResource, IdentityResourceDto>(identityResource);
        }
    }
}
