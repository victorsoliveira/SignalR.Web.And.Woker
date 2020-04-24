using Owin;

namespace Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Informar uma ConnectionString de Azure Service Bus caso queira utilizar o BackPlane

            //GlobalHost.DependencyResolver.UseServiceBus(new ServiceBusScaleoutConfiguration("", "signalr"));

            app.MapSignalR();
        }
    }
}