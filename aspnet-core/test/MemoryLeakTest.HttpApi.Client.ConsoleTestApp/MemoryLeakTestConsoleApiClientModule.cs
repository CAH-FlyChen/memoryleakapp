using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MemoryLeakTest.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MemoryLeakTestHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MemoryLeakTestConsoleApiClientModule : AbpModule
    {
        
    }
}
