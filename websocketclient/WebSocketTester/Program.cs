using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketTester
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 1; i++)
            {
                Random r = new Random();
                Thread.Sleep(r.Next(300, 1000));
                Console.WriteLine($"starting thread {i}");
                Task.Run(async()=> {
                    Tester t = new Tester();
                    await t.ConnectOnce();
                });
            }
            Console.Read();
        }

        public class Tester
        {
            public async Task ConnectOnce()
            {

                var webSocket = new ClientWebSocket();
                string id = "0b919186-b12b-453d-bb1f-79ab39336b9a";
                Console.WriteLine($"connecting  {id}");
                webSocket.Options.SetRequestHeader("ClientId", id);
                webSocket.Options.SetRequestHeader("MachineName", Environment.MachineName);
                try
                {
                    await webSocket.ConnectAsync(new Uri("ws://localhost:44355/ws"), CancellationToken.None);
                    //await webSocket.ConnectAsync(new Uri("ws://localhost:80/ws"), CancellationToken.None);
                    for (int i=0;i<10000;i++)
                    {
                        Thread.Sleep(100);
                        await webSocket.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes("abc")), WebSocketMessageType.Text, true, CancellationToken.None);
                        Console.WriteLine(i);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //for (var i = 0; i < 1000; i++)
                //{
                //    await webSocket.SendAsync(new ArraySegment<byte>(new byte[] { }), WebSocketMessageType.Binary, true, CancellationToken.None);
                //    Thread.Sleep(5 * 1000);
                //}

                return;
            }
        }


        
    }
}
