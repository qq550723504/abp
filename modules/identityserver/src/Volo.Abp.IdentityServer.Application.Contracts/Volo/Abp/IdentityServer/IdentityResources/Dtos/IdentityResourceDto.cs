using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.IdentityServer.IdentityResources.Dtos
{
    public class IdentityResourceDto : ExtensibleFullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public bool Required { get; set; }

        public bool Emphasize { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }

        //public List<IdentityClaimDto> UserClaims { get; set; }

        public string ConcurrencyStamp { get ; set ; }
    }
}
