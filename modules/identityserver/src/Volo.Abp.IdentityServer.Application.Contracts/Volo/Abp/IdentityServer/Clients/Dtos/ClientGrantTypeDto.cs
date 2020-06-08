using System;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientGrantTypeDto
    {
        public Guid ClientId { get; set; }

        public string GrantType { get; set; }
    }
}
