using Grpc.Net.Client;
using GrpcGreeter;
using System;
using System.Threading.Tasks;

namespace Client.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new GrpcGreeter.Greeter.GreeterClient(channel);
            for (int i = 0; i < 100_000_000; i++)
            {
                var reply = await client.SayHelloAsync(
                                              new HelloRequest { Name = $"GreeterClient {i}" });
                Console.WriteLine("Greeting: " + reply.Message);

            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
