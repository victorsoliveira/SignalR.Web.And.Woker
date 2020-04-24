using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Business
{
    public class MainHubClient
    {
        private IHubProxy _hubProxy;

        public Task Start()
        {
            var hubConnection = new HubConnection("http://localhost:5000");

            _hubProxy = hubConnection.CreateHubProxy("main");

            var sub = _hubProxy.Subscribe("onMessage");
            sub.Received += SubOnReceived;

            return hubConnection.Start();
        }

        public Task SendMessage(string tenantId, int counter)
        {
            return _hubProxy.Invoke("message", tenantId, $"Mensagem {counter} para o tenant {tenantId} ...");
        }

        private void SubOnReceived(IList<JToken> obj)
        {
            Console.Write(JsonConvert.SerializeObject(obj));
        }
    }
}