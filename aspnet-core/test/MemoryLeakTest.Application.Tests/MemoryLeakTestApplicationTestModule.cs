using Volo.Abp.Modularity;

namespace MemoryLeakTest
{
    [DependsOn(
        typeof(MemoryLeakTestApplicationModule),
        typeof(MemoryLeakTestDomainTestModule)
        )]
    public class MemoryLeakTestApplicationTestModule : AbpModule
    {

    }
}