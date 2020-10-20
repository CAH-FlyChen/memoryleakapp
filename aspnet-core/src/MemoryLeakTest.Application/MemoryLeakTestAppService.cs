using System;
using System.Collections.Generic;
using System.Text;
using MemoryLeakTest.Localization;
using Volo.Abp.Application.Services;

namespace MemoryLeakTest
{
    /* Inherit your application services from this class.
     */
    public abstract class MemoryLeakTestAppService : ApplicationService
    {
        protected MemoryLeakTestAppService()
        {
            LocalizationResource = typeof(MemoryLeakTestResource);
        }
    }
}
