using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiResources.Dtos;

namespace Volo.Abp.IdentityServer.Web.Pages.IdentityServer.ApiResources
{
    public class CreateModalModel : IdentityServerPageModel
    {
        [BindProperty]
        public ApiResourceViewModel ApiResource { get; set; }

        protected IApiResourceAppService ApiResourceAppService { get; }

        public CreateModalModel(IApiResourceAppService apiResourceAppService)
        {
            ApiResourceAppService = apiResourceAppService;
        }

        public virtual Task<IActionResult> OnGetAsync()
        {
            return Task.FromResult<IActionResult>(Page());
        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<ApiResourceViewModel, ApiResourceDto>(ApiResource);
            await ApiResourceAppService.CreateAsync(input);

            return NoContent();
        }

        public class ApiResourceViewModel
        {

            [Required]
            public string Name { get; set; }

            public string DisplayName { get; set; }

            public string Description { get; set; }

            public bool Enabled { get; set; }

        }

    }
}
