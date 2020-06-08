using System;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientIdPRestrictionDto
    {
        public Guid ClientId { get; set; }

        public string Provider { get; set; }
    }
}
