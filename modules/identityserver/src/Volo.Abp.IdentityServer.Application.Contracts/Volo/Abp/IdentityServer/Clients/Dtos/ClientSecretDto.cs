using System;
using Volo.Abp.IdentityServer.Dtos;

namespace Volo.Abp.IdentityServer.Clients.Dtos
{
    public class ClientSecretDto:SecretDto
    {
        public Guid ClientId { get; set; }
    }
}
