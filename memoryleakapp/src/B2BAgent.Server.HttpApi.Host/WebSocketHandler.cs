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

    public abstract class WebSocketHandler
    {
        ILogger<MySocketMessageHandler> xlogger;


        public WebSocketHandler(ILogger<MySocketMessageHandler> xlogger)
        {
            this.xlogger = xlogger;
        }


        public virtual async Task HandleAsync(HttpContext context,WebSocket socket)
        {
        }


        public virtual async Task OnDisconnected(WebSocket socket)
        {
            await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
        }

        public virtual async Task OnReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
        }
    }

}
