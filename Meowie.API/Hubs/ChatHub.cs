using Meowie.Lib.Data;
using Microsoft.AspNetCore.SignalR;

namespace Meowie.API.Hubs;

public class ChatHub : Hub
{

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendChat(ChatModel chatMessage)
    {
        chatMessage.TimeStamp = DateTime.Now;
        await Clients.All.SendAsync("ReceiveChat", chatMessage);
    }
}