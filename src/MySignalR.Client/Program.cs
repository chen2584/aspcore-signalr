using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace MySignalR.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/ChatHub")
                .Build();

            await connection.StartAsync();
            connection.Closed += async (error) =>
            {
                // Some closed
                Console.WriteLine("Reconnecting...");
                await connection.StartAsync();
            };

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"{user}: {message}");
            });
            await connection.SendAsync("SendMessage", "Client", "Hello from Client!");
            Console.ReadLine();
        }
    }
}
