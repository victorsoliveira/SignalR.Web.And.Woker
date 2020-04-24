using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Business
{
    [HubName("main")]
    public class MainHub : Hub
    {
        public void Message(string tenantId, string message)
        {
            Console.WriteLine($"sending message {message}");
            Clients.Group(tenantId).onMessage(message);
        }

        public override Task OnConnected()
        {
            var tenant = Context.QueryString.Get("tenant");
            if (tenant != null)
            {
                Groups.Add(Context.ConnectionId, tenant);
            }

            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            var tenant = Context.QueryString.Get("tenant");
            if (tenant != null)
            {
                Groups.Add(Context.ConnectionId, tenant);
            }

            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var tenant = Context.QueryString.Get("tenant");
            if (tenant != null)
            {
                Groups.Remove(Context.ConnectionId, tenant);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}

