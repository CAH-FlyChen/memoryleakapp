using System;
using System.Collections.Generic;
using System.Text;
using B2BAgent.Server.Localization;
using Volo.Abp.Application.Services;

namespace B2BAgent.Server
{
    /* Inherit your application services from this class.
     */
    public abstract class ServerAppService : ApplicationService
    {
        protected ServerAppService()
        {
            LocalizationResource = typeof(ServerResource);
        }
    }
}
