using System;
using Volo.Abp.IdentityServer.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources.Dtos
{
    public class ApiSecretDto:SecretDto
    {
        public Guid ApiResourceId { get; set; }

    }
}
