using System.Threading.Tasks;

namespace MemoryLeakTest.Data
{
    public interface IMemoryLeakTestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
