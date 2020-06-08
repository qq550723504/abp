using System;
using Volo.Abp.IdentityServer.Dtos;

namespace Volo.Abp.IdentityServer.IdentityResources.Dtos
{
    public class IdentityClaimDto : UserClaimDto
    {
        public Guid IdentityResourceId { get; set; }
    }
}
