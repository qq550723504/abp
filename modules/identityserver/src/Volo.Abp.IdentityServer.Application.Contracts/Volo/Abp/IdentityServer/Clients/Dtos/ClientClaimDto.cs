using System;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientClaimDto
    {
        public Guid ClientId { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }
}
