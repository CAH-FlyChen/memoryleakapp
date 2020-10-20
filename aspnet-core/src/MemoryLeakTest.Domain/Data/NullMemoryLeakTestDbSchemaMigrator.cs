using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MemoryLeakTest.Data
{
    /* This is used if database provider does't define
     * IMemoryLeakTestDbSchemaMigrator implementation.
     */
    public class NullMemoryLeakTestDbSchemaMigrator : IMemoryLeakTestDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}