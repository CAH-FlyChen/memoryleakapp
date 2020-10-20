using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MemoryLeakTest.EntityFrameworkCore
{
    [DependsOn(
        typeof(MemoryLeakTestEntityFrameworkCoreModule)
        )]
    public class MemoryLeakTestEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MemoryLeakTestMigrationsDbContext>();
        }
    }
}
