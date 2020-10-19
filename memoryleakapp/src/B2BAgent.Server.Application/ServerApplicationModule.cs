using Microsoft.Extensions.Configuration;
using System.IO;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.MultiTenancy.ConfigurationStore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace B2BAgent.Server
{
    [DependsOn(
        typeof(ServerDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(ServerApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpMultiTenancyModule),
        typeof(AbpTenantManagementApplicationModule)
        )]
    public class ServerApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ServerApplicationModule>();

            });

            //gil add
            //Configure<AbpAspNetCoreMvcOptions>(options =>
            //{
            //    options
            //        .ConventionalControllers
            //        .Create(typeof(ServerApplicationModule).Assembly);
            //});

            //Configure<AbpTenantResolveOptions>(options =>
            //{
            //    options.TenantResolvers.Add(new MyCustomTenantResolveContributor());
            //});

            Configure<AbpDefaultTenantStoreOptions>(BuildConfiguration());
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

    }
}
