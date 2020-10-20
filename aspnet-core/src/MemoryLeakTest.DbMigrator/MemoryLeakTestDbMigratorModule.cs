using MemoryLeakTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MemoryLeakTest.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MemoryLeakTestEntityFrameworkCoreDbMigrationsModule),
        typeof(MemoryLeakTestApplicationContractsModule)
        )]
    public class MemoryLeakTestDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
