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
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Clients.Dtos;
using Volo.Abp.ObjectMapping;

namespace Volo.Abp.IdentityServer.Web.Pages.IdentityServer.Clients
{
    public class EditModalModel : IdentityServerPageModel
    {
        [BindProperty]
        public ClientViewModel Client { get; set; }

        protected IClientAppService ClientAppService { get; }

        public EditModalModel(IClientAppService clientAppService)
        {
            ClientAppService = clientAppService;
        }

        public virtual async Task OnGetAsync(Guid id)
        {
            Client = ObjectMapper.Map<ClientDto, ClientViewModel>(
               await ClientAppService.GetAsync(id)
           );
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<ClientViewModel, ClientDto>(Client);
            await ClientAppService.UpdateAsync(Client.Id, input);

            return NoContent();
        }

        public class ClientViewModel : IHasConcurrencyStamp
        {
            [Required]
            public string ClientId { get; set; }

            public string ClientName { get; set; }

            public string Description { get; set; }

            public bool Enabled { get; set; }

            [HiddenInput]
            public Guid Id { get; set; }

            [HiddenInput]
            public string ConcurrencyStamp { get; set; }
        }
    }
}