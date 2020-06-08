using System;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientRedirectUriDto
    {
        public Guid ClientId { get; set; }

        public string RedirectUri { get; set; }
    }
}
