using System;
using Volo.Abp.IdentityServer.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources.Dtos
{
    public class ApiScopeClaimDto : UserClaimDto
    {
        public Guid ApiResourceId { get; set; }

        public string Name { get; set; }

    }
}
