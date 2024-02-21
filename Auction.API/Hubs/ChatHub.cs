using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace Auction.API.Hubs;
[SignalRHub]
public class ChatHub : Hub
{
    public async Task SendPrivateMessage(string user, string message) 
        => await Clients.User(user).SendAsync("ReceiveMessage", message);


}
