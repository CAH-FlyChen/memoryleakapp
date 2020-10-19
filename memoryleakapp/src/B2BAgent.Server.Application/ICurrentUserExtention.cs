using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Users;

namespace B2BAgent.Server
{
    public static class ICurrentUserExtention
    {
        public static Guid GetMerchantId(this ICurrentUser currentUser)
        {
            var merchantId = new Guid(currentUser.FindClaim("merchant_id").Value);
            return merchantId;
        }
    }
}
