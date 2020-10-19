using B2BAgent.Server.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace B2BAgent.Server.Permissions
{
    public class ServerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ServerPermissions.GroupName);

            //Define your own permissions here. Example:
            myGroup.AddPermission(ServerPermissions.GloableUserManagePermission, L("Permission:GloableUserManagePermission"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ServerResource>(name);
        }
    }
}
