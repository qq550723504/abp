using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.IdentityServer.ApiResources.Dtos
{
    public class ApiResourceDto : ExtensibleFullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        //public List<ApiSecretDto> Secrets { get; set; }

        //public List<ApiScopeDto> Scopes { get; set; }

        //public List<ApiResourceClaimDto> UserClaims { get; set; }

        public string ConcurrencyStamp { get ; set; }
    }
}
