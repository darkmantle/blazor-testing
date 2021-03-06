using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TodoList.Hubs
{
    public class TodoHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}