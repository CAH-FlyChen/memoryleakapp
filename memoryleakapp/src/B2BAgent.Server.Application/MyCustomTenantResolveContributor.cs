using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.MultiTenancy;

namespace B2BAgent.Server
{
    public class MyCustomTenantResolveContributor : ITenantResolveContributor
    {
        public string Name => "MyCustomTenantResolve";

        public void Resolve(ITenantResolveContext context)
        {
            context.TenantIdOrName = "xxxx"; //从其他地方获取租户id或租户名字...
        }
    }
}
