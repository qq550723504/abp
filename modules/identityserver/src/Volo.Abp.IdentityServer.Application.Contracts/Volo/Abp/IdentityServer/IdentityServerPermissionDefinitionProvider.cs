using Volo.Abp.Authorization.Permissions;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Localization;

namespace Volo.Abp.IdentityServer
{
    public class IdentityServerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var identityServerGroup = context.AddGroup(IdentityServerPermissions.GroupName, L("Permission:IdentityServerManagement"));

            var apiResourcesPermission = identityServerGroup.AddPermission(IdentityServerPermissions.ApiResources.Default, L("Permission:ApiResourceManagement"));
            apiResourcesPermission.AddChild(IdentityServerPermissions.ApiResources.Create, L("Permission:Create"));
            apiResourcesPermission.AddChild(IdentityServerPermissions.ApiResources.Update, L("Permission:Edit"));
            apiResourcesPermission.AddChild(IdentityServerPermissions.ApiResources.Delete, L("Permission:Delete"));
            apiResourcesPermission.AddChild(IdentityServerPermissions.ApiResources.ManagePermissions, L("Permission:ChangePermissions"));

            var clientsPermission = identityServerGroup.AddPermission(IdentityServerPermissions.Clients.Default, L("Permission:ClientManagement"));
            clientsPermission.AddChild(IdentityServerPermissions.Clients.Create, L("Permission:Create"));
            clientsPermission.AddChild(IdentityServerPermissions.Clients.Update, L("Permission:Edit"));
            clientsPermission.AddChild(IdentityServerPermissions.Clients.Delete, L("Permission:Delete"));
            clientsPermission.AddChild(IdentityServerPermissions.Clients.ManagePermissions, L("Permission:ChangePermissions"));

            var identityResourcePermission = identityServerGroup.AddPermission(IdentityServerPermissions.IdentityResources.Default, L("Permission:IdentityResourceManagement"));
            identityResourcePermission.AddChild(IdentityServerPermissions.IdentityResources.Create, L("Permission:Create"));
            identityResourcePermission.AddChild(IdentityServerPermissions.IdentityResources.Update, L("Permission:Edit"));
            identityResourcePermission.AddChild(IdentityServerPermissions.IdentityResources.Delete, L("Permission:Delete"));
            identityResourcePermission.AddChild(IdentityServerPermissions.IdentityResources.ManagePermissions, L("Permission:ChangePermissions"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpIdentityServerResource>(name);
        }
    }
}
