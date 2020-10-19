//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.Authorization.Permissions;
//using Volo.Abp.Security.Claims;

//namespace B2BAgent.Server
//{
//    /// <summary>
//    /// 基于角色的授权
//    /// </summary>
//    public class RolePermissionValueProvider : PermissionValueProvider
//    {
//        public const string ProviderName = "Role";

//        public override string Name => ProviderName;

//        public RolePermissionValueProvider(IPermissionStore permissionStore)
//            : base(permissionStore)
//        {

//        }

//        public override async Task<PermissionGrantResult> CheckAsync(PermissionValueCheckContext context)
//        {
//            var roles = context.Principal?.FindAll(AbpClaimTypes.Role).Select(c => c.Value).ToArray();
//            if (roles == null || !roles.Any())
//            {
//                return PermissionGrantResult.Undefined;
//            }

//            foreach (var role in roles)
//            {
//                if (await PermissionStore.IsGrantedAsync(context.Permission.Name, Name, role))
//                {
//                    return PermissionGrantResult.Granted;
//                }
//            }

//            return PermissionGrantResult.Undefined;
//        }
//    }

//}
