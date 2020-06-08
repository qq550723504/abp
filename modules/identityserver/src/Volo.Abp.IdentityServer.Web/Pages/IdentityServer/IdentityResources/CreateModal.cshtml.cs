using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.Domain.Entities;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.IdentityServer.IdentityResources.Dtos;

namespace Volo.Abp.IdentityServer.Web.Pages.IdentityServer.IdentityResources
{
    public class CreateModalModel : IdentityServerPageModel
    {
        [BindProperty]
        public IdentityResourceViewModel IdentityResource { get; set; }

        protected IIdentityResourceAppService IdentityResourceAppService { get; }

        public CreateModalModel(IIdentityResourceAppService identityResourceAppService)
        {
            IdentityResourceAppService = identityResourceAppService;
        }

        public virtual Task<IActionResult> OnGetAsync()
        {
            return Task.FromResult<IActionResult>(Page());
        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<IdentityResourceViewModel, IdentityResourceDto>(IdentityResource);
            await IdentityResourceAppService.CreateAsync(input);

            return NoContent();
        }

        public class IdentityResourceViewModel
        {
            [Required]
            public string Name { get; set; }

            public string DisplayName { get; set; }

            public string Description { get; set; }

            public bool Required { get; set; }

            public bool Emphasize { get; set; }

            public bool ShowInDiscoveryDocument { get; set; }

            public bool Enabled { get; set; }
        }

    }
}
