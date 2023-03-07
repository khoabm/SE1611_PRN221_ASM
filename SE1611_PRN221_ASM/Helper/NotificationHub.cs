using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace SE1611_PRN221_ASM.Helper
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var userId = Context.User.FindFirst("email")?.Value;
            await Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

        public Task NotifyOrderStatusChanged(string userId)
        {
            //,string message
            //Console.WriteLine(Context.User.Identity.Name);
            //var userId = Context.User.FindFirst("email")?.Value;
            //Console.WriteLine("Notificate to: " + userId+"Length"+userId.Length);
            Console.WriteLine(userId);
            return Clients.User(userId).SendAsync("ReceiveMessage", "ga` qua z");
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
