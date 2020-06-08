using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.IdentityServer.ApiResources.Dtos;
using Volo.Abp.IdentityServer.Clients.Dtos;
using Volo.Abp.IdentityServer.IdentityResources.Dtos;
using CreateApiResourceModalModel=Volo.Abp.IdentityServer.Web.Pages.IdentityServer.ApiResources.CreateModalModel;
using EditApiResourceModalModel = Volo.Abp.IdentityServer.Web.Pages.IdentityServer.ApiResources.EditModalModel;
using CreateClientModalModel= Volo.Abp.IdentityServer.Web.Pages.IdentityServer.Clients.CreateModalModel;
using EditClientModalModel = Volo.Abp.IdentityServer.Web.Pages.IdentityServer.Clients.EditModalModel;
using CreateIdentityResourceModalModel= Volo.Abp.IdentityServer.Web.Pages.IdentityServer.IdentityResources.CreateModalModel;
using EditIdentityResourceModalModel = Volo.Abp.IdentityServer.Web.Pages.IdentityServer.IdentityResources.EditModalModel;

namespace Volo.Abp.IdentityServer.Web
{
    public class AbpIdentityServerWebAutoMapperProfile : Profile
    {
        public AbpIdentityServerWebAutoMapperProfile() 
        {
            CreateApiResourceMappings();
            CreateClientMappings();
            CreateIdentityResourceMappings();
        }

        protected virtual void CreateApiResourceMappings() 
        {
            //CreateModal
            CreateMap<ApiResourceDto, CreateApiResourceModalModel.ApiResourceViewModel>();
            CreateMap<CreateApiResourceModalModel.ApiResourceViewModel, ApiResourceDto>()
                .Ignore(x => x.ExtraProperties);

            //EditModal
            CreateMap<ApiResourceDto, EditApiResourceModalModel.ApiResourceViewModel>();
            CreateMap<EditApiResourceModalModel.ApiResourceViewModel, ApiResourceDto>()
                .Ignore(x => x.ExtraProperties);
        }

        protected virtual void CreateClientMappings()
        {
            //CreateModal
            CreateMap<ClientDto, CreateClientModalModel.ClientViewModel>();
            CreateMap<CreateClientModalModel.ClientViewModel, ClientDto>()
                .Ignore(x => x.ExtraProperties);

            //EditModal
            CreateMap<ClientDto, EditClientModalModel.ClientViewModel>();
            CreateMap<EditClientModalModel.ClientViewModel, ClientDto>()
                .Ignore(x => x.ExtraProperties);
        }

        protected virtual void CreateIdentityResourceMappings() 
        {
            //CreateModal
            CreateMap<IdentityResourceDto, CreateIdentityResourceModalModel.IdentityResourceViewModel>();
            CreateMap<CreateIdentityResourceModalModel.IdentityResourceViewModel, IdentityResourceDto>()
                .Ignore(x => x.ExtraProperties);

            //EditModal
            CreateMap<IdentityResourceDto, EditIdentityResourceModalModel.IdentityResourceViewModel>();
            CreateMap<EditIdentityResourceModalModel.IdentityResourceViewModel, IdentityResourceDto>()
                .Ignore(x => x.ExtraProperties);
        }
    }
}
