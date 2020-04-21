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
        public override async Task OnConnected()
        {
            await Clients.All.onConnected(Context.ConnectionId, Context.User.Identity.Name);
            await base.OnConnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            await Clients.All.onDisconected(Context.ConnectionId, Context.User.Identity.Name);
            await base.OnDisconnected(stopCalled);
        }

        //TO EVERYONE
        public void SendMessagesToAll(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        //TO CALLLER
        public void SendMessagesToCaller(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.Caller.addNewMessageToPage(name, message);
        }

        //TO USER
        public void SendMessageToUser(string connectionId, string message)
        {
            Clients.Client(connectionId).addNewMessageToPage(message);
        }

        //JOIN GROUP
        public void JoinGroup(string group)
        {
            Groups.Add(Context.ConnectionId, group);
        }

        //SEND MESSAGE TO GROUP
        public void SendMessageToGroup(string group, string message)
        {

            var name = Context.User.Identity.Name;
            Clients.Group(group).addNewMessageToPage(name, message);
        }

    }
}