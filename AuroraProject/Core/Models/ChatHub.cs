using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AuroraProject.Core.Models
{
    public class ChatHub : Hub
    {
        public void SendChatMessage(string name, string message)
        {
            name = Context.User.Identity.Name;
            Clients.Group(name).addChatMessage(name, message);
            Clients.Group("2@2.com").addChatMessage(name, message);
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }
    }
}