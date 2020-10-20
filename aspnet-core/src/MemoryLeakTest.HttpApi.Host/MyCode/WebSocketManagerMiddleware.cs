using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace B2BAgent.Server
{
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate _next;
        public WebSocketManagerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<WebSocketManagerMiddleware> logger, MySocketMessageHandler webSocketHandler)
        {
            try
            {
                if (!context.WebSockets.IsWebSocketRequest) { return; }
                var socket = await context.WebSockets.AcceptWebSocketAsync();
                await webSocketHandler.HandleAsync(context, socket);
            }
            catch (Exception e)
            {
                logger.LogError(e,"Socket处理错误最外层捕获");
            }
        }

       
    }
}
