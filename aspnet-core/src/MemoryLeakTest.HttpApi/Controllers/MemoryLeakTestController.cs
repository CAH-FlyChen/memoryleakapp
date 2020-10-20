using MemoryLeakTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MemoryLeakTest.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class MemoryLeakTestController : AbpController
    {
        protected MemoryLeakTestController()
        {
            LocalizationResource = typeof(MemoryLeakTestResource);
        }
    }
}