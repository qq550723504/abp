using System;
using Volo.Abp.IdentityServer.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources.Dtos
{
    public class ApiResourceClaimDto:UserClaimDto
    {
        public Guid ApiResourceId { get; set; }
    }
}
