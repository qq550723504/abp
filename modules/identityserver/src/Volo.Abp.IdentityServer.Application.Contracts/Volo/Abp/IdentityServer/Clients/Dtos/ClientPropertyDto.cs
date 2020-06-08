using System;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientPropertyDto
    {
        public Guid ClientId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
