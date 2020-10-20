using B2BAgent.Server.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace B2BAgent.Server
{
    public class MySocketMessageHandler : ITransientDependency
    {
        ILogger<MySocketMessageHandler> logger;
        IServiceProvider serviceProvider;
        IRepository<Domains.ERPBrand> erpRepo;
        IServiceScopeFactory serviceScopeFactory;
        public MySocketMessageHandler( ILogger<MySocketMessageHandler> logger,
            IRepository<Domains.ERPBrand> erpRepo, IServiceScopeFactory serviceScopeFactory
            )
        {
            this.logger = logger;
            this.erpRepo = erpRepo;
            this.serviceScopeFactory = serviceScopeFactory;
        }


        /// <summary>
        /// 最早进入的connected
        /// </summary>
        /// <param name="context"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        public async Task HandleAsync(HttpContext context, WebSocket socket)
        {

            //process details
            try
            {
                const int BUFFER_LENGTG = 1024;//1k
                if (socket.State != WebSocketState.Open)
                    return;
                while (true)
                {
                    try
                    {
                        WebSocketReceiveResult result = null;
                        var allBytes = new List<byte>();
                        do
                        {
                            var buffer = new byte[BUFFER_LENGTG];
                            if (socket.State == WebSocketState.Open || socket.State == WebSocketState.CloseSent)
                            {
                                result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                            }
                            else
                            {
                                return;
                            }

                            if (socket.State == WebSocketState.Open)
                            {
                                for (int i = 0; i < result.Count; i++)
                                {
                                    allBytes.Add(buffer[i]);
                                }
                            }
                            else if (socket.State == WebSocketState.CloseSent)
                            {
                                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                                return;
                            }
                            else
                            {
                                return;
                            }

                        }
                        while (!result.EndOfMessage);

                        //may leek
                        using (var scope = this.serviceScopeFactory.CreateScope())
                        {
                            var erpRepox = scope.ServiceProvider.GetRequiredService<IRepository<Domains.ERPBrand>>();
                            var rrrr = erpRepox.ToList();
                        }

                        logger.LogInformation($"HeartBeat");


                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + ex.StackTrace);
            }
        }
    }
}
