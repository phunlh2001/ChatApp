using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string username, string message, string avatar)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message, avatar);
        }
    }
}
