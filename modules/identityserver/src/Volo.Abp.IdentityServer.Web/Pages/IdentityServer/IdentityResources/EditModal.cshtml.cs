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
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.IdentityServer.IdentityResources.Dtos;

namespace Volo.Abp.IdentityServer.Web.Pages.IdentityServer.IdentityResources
{
    public class EditModalModel : IdentityServerPageModel
    {
        [BindProperty]
        public IdentityResourceViewModel IdentityResource { get; set; }

        protected IIdentityResourceAppService IdentityResourceAppService { get; }

        public EditModalModel(IIdentityResourceAppService identityUserAppService)
        {
            IdentityResourceAppService = identityUserAppService;
        }

        public virtual async Task OnGetAsync(Guid id)
        {
            IdentityResource = ObjectMapper.Map<IdentityResourceDto, IdentityResourceViewModel>(
              await IdentityResourceAppService.GetAsync(id)
          );
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<IdentityResourceViewModel, IdentityResourceDto>(IdentityResource);
            await IdentityResourceAppService.UpdateAsync(IdentityResource.Id, input);

            return NoContent();
        }

        public class IdentityResourceViewModel : IHasConcurrencyStamp
        {
            [Required]
            public string Name { get; protected set; }

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