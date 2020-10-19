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
using MySqlX.XDevAPI.Common;
using NLog;

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
                // If the request is not a WebSocket request, it just exits the middleware.

                if (!context.WebSockets.IsWebSocketRequest) { return; }

                // If it is a WebSockets request,
                // then it accepts the connection and passes the socket to the OnConnected method from the WebSocketHandler.
                var socket = await context.WebSockets.AcceptWebSocketAsync();


                await webSocketHandler.HandleAsync(context, socket);



                // while the socket is in the Open state, it awaits for the receival of new data.


                // When it receives the data, it decides wether to pass the context to the ReceiveAsync method of WebSocketHandler
                // (that's why you need to pass an actual implementation of the abstract WebSocketHandler class)
                // or to the OnDisconnected method (if the message type is Close).

            }
            catch (Exception e)
            {
                logger.LogError(e,"Socket处理错误最外层捕获");
                //保证不崩掉
            }
        }

       
    }
}
