using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace TesterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var webSocket = new ClientWebSocket();
            string id = "0b919186-b12b-453d-bb1f-79ab39336b9a";
            try
            {
                Console.WriteLine("press enter after server started, to begin call socket");
                Console.ReadKey();

                Task.Run(async () => {
                    try
                    {
                        Console.WriteLine($"connecting  {id}");
                        webSocket.Options.SetRequestHeader("ClientId", id);
                        webSocket.Options.SetRequestHeader("MachineName", Environment.MachineName);
                        await webSocket.ConnectAsync(new Uri("ws://localhost:44390/ws"), CancellationToken.None);
                        for (int i = 0; i < 10000; i++)
                        {
                            try
                            {

                                Random r = new Random();
                                Thread.Sleep(r.Next(100, 300));
                                await webSocket.SendAsync(new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes("abc")), WebSocketMessageType.Text, true, CancellationToken.None);
                                Console.WriteLine(i);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
