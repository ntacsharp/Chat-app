using ChatService;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_App.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string botUser;

        public ChatHub()
        {
            botUser = "myBot";
        }
        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", botUser, $"{userConnection.User} has joined {userConnection.Room}");
        }
    }
}
