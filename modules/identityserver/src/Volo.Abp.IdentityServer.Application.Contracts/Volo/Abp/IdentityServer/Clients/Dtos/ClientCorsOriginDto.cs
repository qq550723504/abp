using System;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientCorsOriginDto
    {
        public Guid ClientId { get; set; }

        public string Origin { get; set; }
    }
}
