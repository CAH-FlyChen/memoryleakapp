using System;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using B2BAgent.Server.EntityFrameworkCore;
using B2BAgent.Server.MultiTenancy;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using LogDashboard;
using LogDashboard.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace B2BAgent.Server
{
    [DependsOn(
        typeof(ServerHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(ServerApplicationModule),
        typeof(ServerEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreSerilogModule)
        )]
    public class ServerHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            ConfigureConventionalControllers();
            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureCache(configuration);
            ConfigureVirtualFileSystem(context);
            ConfigWebSockets(context);
            ConfigureRedis(context, configuration, hostingEnvironment);
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context);

            context.Services.AddLogDashboard(opt => opt.SetRootPath(hostingEnvironment.ContentRootPath));
        }

        private void ConfigWebSockets(ServiceConfigurationContext context)
        {
            context.Services.AddWebSocketService();
        }

        private void ConfigureCache(IConfiguration configuration)
        {
            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "Server:";
            });
        }

        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                //Configure<AbpVirtualFileSystemOptions>(options =>
                //{
                //    options.FileSets.ReplaceEmbeddedByPhysical<ServerDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}B2BAgent.Server.Domain.Shared"));
                //    options.FileSets.ReplaceEmbeddedByPhysical<ServerDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}B2BAgent.Server.Domain"));
                //    options.FileSets.ReplaceEmbeddedByPhysical<ServerApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}B2BAgent.Server.Application.Contracts"));
                //    options.FileSets.ReplaceEmbeddedByPhysical<ServerApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}B2BAgent.Server.Application"));
                //});
            }
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(ServerApplicationModule).Assembly);
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "Server";
                });
        }

        private static void ConfigureSwaggerServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "DDI服务器端API文档", Version = "v1"});
                    options.DocInclusionPredicate((docName, description) => true);
                    options.EnableAnnotations(true);
                    var p = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    options.IncludeXmlComments( Path.Combine(p,"B2BAgent.Server.Application.xml"),true);
                    options.IncludeXmlComments(Path.Combine(p, "B2BAgent.Server.Domain.xml"),true);
                    options.IncludeXmlComments(Path.Combine(p, "B2BAgent.Server.Application.Contracts.xml"),true);
                    options.IncludeXmlComments(Path.Combine(p, "B2BAgent.Server.HttpApi.Host.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.Account.HttpApi.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.Account.Application.Contracts.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.Identity.Application.Contracts.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.Identity.HttpApi.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.TenantManagement.HttpApi.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.TenantManagement.Application.Contracts.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.FeatureManagement.Application.Contracts.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.FeatureManagement.HttpApi.xml"), true);
                    options.IncludeXmlComments(Path.Combine(p, "Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy.xml"), true);
                });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });
        }

        private void ConfigureRedis(
            ServiceConfigurationContext context,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            if (!hostingEnvironment.IsDevelopment())
            {
                var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
                context.Services
                    .AddDataProtection()
                    .PersistKeysToStackExchangeRedis(redis, "Server-Protection-Keys");
            }
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseCalculateExecutionTime();


            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);

            //添加websockts支持
            app.UseWebSockets();
            //process /ws request on websocket
            app.MapWebSocketManager("/ws");


            app.UseAuthentication();
            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }
            app.UseAuthorization();
            app.UseAbpRequestLocalization();

            app.UseSwagger(opt =>
            {
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Server API");
                //options.SwaggerEndpoint("/swagger/v1/swagger.json", "Server API");
                //var currDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                //var jsPath = Path.Combine(currDir, "wwwroot\\APIUI.Scripts.swagger.js");
                //options.InjectOnCompleteJavaScript(jsPath);
                options.ConfigObject.DocExpansion = DocExpansion.None;
            });

            //app.UseAuditing();
            
            
            app.UseAbpSerilogEnrichers();
            //app.UseMvcWithDefaultRouteAndArea();
            app.UseConfiguredEndpoints();
            app.UseLogDashboard();
        }
    }
}
