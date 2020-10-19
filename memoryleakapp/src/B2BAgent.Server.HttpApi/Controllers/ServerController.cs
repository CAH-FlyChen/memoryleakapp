using B2BAgent.Server.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace B2BAgent.Server.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ServerController : AbpController
    {
        protected ServerController()
        {
            LocalizationResource = typeof(ServerResource);
        }
    }
}