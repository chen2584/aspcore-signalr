using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MySignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            System.Console.WriteLine($"{user}: {message}");
        }
    }
}