using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Clients.Dtos;

namespace Volo.Abp.IdentityServer.Web.Pages.IdentityServer.Clients
{
    public class CreateModalModel : IdentityServerPageModel
    {
        [BindProperty]
        public ClientViewModel Client { get; set; }

        protected IClientAppService ClientAppService { get; }

        public CreateModalModel(IClientAppService clientAppService)
        {
            ClientAppService = clientAppService;
        }

        public virtual Task<IActionResult> OnGetAsync()
        {
            return Task.FromResult<IActionResult>(Page());
        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<ClientViewModel, ClientDto>(Client);
            await ClientAppService.CreateAsync(input);

            return NoContent();
        }

        public class ClientViewModel 
        {
            public string ClientId { get; set; }

            public string ClientName { get; set; }

            public string Description { get; set; }

            public bool Enabled { get; set; }
        }

    }
}
