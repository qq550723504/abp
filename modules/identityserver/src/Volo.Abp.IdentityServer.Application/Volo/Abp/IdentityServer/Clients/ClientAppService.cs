using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.Clients.Dtos;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.IdentityServer.Clients
{
    [Authorize(IdentityServerPermissions.Clients.Default)]
    public class ClientAppService : AbpIdentityServerAppServiceBase, IClientAppService
    {
        protected IClientRepository ClientRepository;
        public ClientAppService(IClientRepository clientRepository) 
        {
            ClientRepository = clientRepository;
        }

        [Authorize(IdentityServerPermissions.Clients.Create)]
        public virtual async Task<ClientDto> CreateAsync(ClientDto input)
        {
            var client = new Client(
              GuidGenerator.Create(),
              input.ClientId
          );

            input.MapExtraPropertiesTo(client);

            await ClientRepository.InsertAsync(client);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Client, ClientDto>(client);
        }

        [Authorize(IdentityServerPermissions.Clients.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var client = await ClientRepository.FindAsync(id);
            if (client == null)
            {
                return;
            }

            await ClientRepository.DeleteAsync(client);
        }

        public virtual async Task<ClientDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Client, ClientDto>(
               await ClientRepository.FindAsync(id)
           );
        }

        public virtual async Task<PagedResultDto<ClientDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var list = await ClientRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);
            var totalCount = await ClientRepository.GetCountAsync();

            return new PagedResultDto<ClientDto>(
                totalCount,
                ObjectMapper.Map<List<Client>, List<ClientDto>>(list)
                );
        }

        [Authorize(IdentityServerPermissions.Clients.Update)]
        public virtual async Task<ClientDto> UpdateAsync(Guid id, ClientDto input)
        {
            var client = await ClientRepository.FindAsync(id);
            client.ConcurrencyStamp = input.ConcurrencyStamp;

            input.MapExtraPropertiesTo(client);

            await ClientRepository.UpdateAsync(client);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Client, ClientDto>(client);
        }
    }
}
