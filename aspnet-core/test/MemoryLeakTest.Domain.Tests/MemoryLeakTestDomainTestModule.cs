using MemoryLeakTest.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MemoryLeakTest
{
    [DependsOn(
        typeof(MemoryLeakTestEntityFrameworkCoreTestModule)
        )]
    public class MemoryLeakTestDomainTestModule : AbpModule
    {

    }
}