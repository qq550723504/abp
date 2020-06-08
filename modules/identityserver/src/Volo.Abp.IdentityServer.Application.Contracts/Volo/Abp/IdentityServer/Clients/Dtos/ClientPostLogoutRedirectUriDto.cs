using System;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientPostLogoutRedirectUriDto
    {
        public Guid ClientId { get; set; }

        public string PostLogoutRedirectUri { get; set; }
    }
}
