using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.IdentityServer.ApiResources;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.IdentityServer.ApiResources.Dtos;

namespace Volo.Abp.IdentityServer.Web.Pages.IdentityServer.ApiResources
{
    public class EditModalModel : IdentityServerPageModel
    {
        [BindProperty]
        public ApiResourceViewModel ApiResource { get; set; }

        protected IApiResourceAppService ApiResourceAppService { get; }

        public EditModalModel(IApiResourceAppService apiResourceAppService)
        {
            ApiResourceAppService = apiResourceAppService;
        }

        public virtual async Task OnGetAsync(Guid id)
        {
            ApiResource = ObjectMapper.Map<ApiResourceDto, ApiResourceViewModel>(
               await ApiResourceAppService.GetAsync(id)
           );
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<ApiResourceViewModel, ApiResourceDto>(ApiResource);
            await ApiResourceAppService.UpdateAsync(ApiResource.Id, input);

            return NoContent();
        }

        public class ApiResourceViewModel : IHasConcurrencyStamp
        {
            [Required]
            public string Name { get; set; }

            public string DisplayName { get; set; }

            public string Description { get; set; }

            public bool Required { get; set; }

            public bool Emphasize { get; set; }

            public bool ShowInDiscoveryDocument { get; set; }

            public bool Enabled { get; set; }

            [HiddenInput]
            public Guid Id { get; set; }

            [HiddenInput]
            public string ConcurrencyStamp { get; set; }
        }
    }
}