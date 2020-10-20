using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MemoryLeakTest.Data;
using Volo.Abp.DependencyInjection;

namespace MemoryLeakTest.EntityFrameworkCore
{
    public class EntityFrameworkCoreMemoryLeakTestDbSchemaMigrator
        : IMemoryLeakTestDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreMemoryLeakTestDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MemoryLeakTestMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MemoryLeakTestMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}