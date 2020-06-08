using AutoMapper;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiResources.Dtos;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Clients.Dtos;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.IdentityServer.IdentityResources.Dtos;

namespace Volo.Abp.IdentityServer
{
    public class AbpIdentityServerApplicationModuleAutoMapperProfile:Profile
    {
        public AbpIdentityServerApplicationModuleAutoMapperProfile() 
        {
            CreateMap<ApiResource, ApiResourceDto>()
                .MapExtraProperties();

            CreateMap<Client, ClientDto>()
                .MapExtraProperties();

            CreateMap<IdentityResource, IdentityResourceDto>()
                .MapExtraProperties();
        }
    }
}
