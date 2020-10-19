using System.Threading.Tasks;

namespace B2BAgent.Server.Data
{
    public interface IServerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
