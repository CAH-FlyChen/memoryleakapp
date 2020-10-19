
using B2BAgent.Server.Domains;
using EV.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace B2BAgent.Server.EntityFrameworkCore
{
    [DependsOn(
        typeof(ServerDomainModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule),
        typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule)
        )]
    public class ServerEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ServerDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
                //options.AddRepository<ExternalIDS,EfCoreExternalIDSRepository>();
                //options.Entity<Merchant>(opt =>
                //{
                //    //opt.DefaultWithDetailsFunc = q => q.Include(a => a.BusinessTenant)
                //    //    .Include(t => t.OS)
                //    //    .Include(t => t.ERPVersion)
                //    //    .ThenInclude(x => x.ERP);
                //});
                //options.Entity<SysDict>(opt=> {
                //    opt.DefaultWithDetailsFunc = q => q.Include(a => a.SysDictItems);
                //});
                //options.Entity<ConfigTemplate>(opt =>
                //{
                //    opt.DefaultWithDetailsFunc = q => q.Include(a => a.ERPVersion).ThenInclude(x => x.ERP);
                //});
            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also ServerMigrationsDbContextFactory for EF Core tooling. */
                options.UsePostgreSql();
            });
        }
    }
}
