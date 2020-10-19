using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace B2BAgent.Server
{
    public static class WebSocketManagerExtensions
    {
        public static IServiceCollection AddWebSocketService(this IServiceCollection services)
        {
            // Besides from adding the WebSocketConnectionManager service,

            services.AddTransient<MySocketMessageHandler>();
  
            return services;
        }

        // It receives a path and it maps that path using with the WebSocketManagerMiddleware which is passed the specific implementation
        // of WebSocketHandler you provided as argument for the MapWebSocketManager extension method.
        public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app, PathString path)
        {
            return app.Map(path, (_app) => {
                _app.UseMiddleware<WebSocketManagerMiddleware>();
            });
        }
    }
}
