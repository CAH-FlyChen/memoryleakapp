using MemoryLeakTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MemoryLeakTest.Permissions
{
    public class MemoryLeakTestPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MemoryLeakTestPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MemoryLeakTestPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MemoryLeakTestResource>(name);
        }
    }
}
