using System;
using System.Threading.Tasks;
using Business;

namespace Worker
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new MainHubClient();

            await client.Start();

            for (var i = 0; i < 1000; i++)
            {
                var tenantId = (i % 2 == 0) ? "tenant-1" : "tenant-2";
                await client.SendMessage(tenantId, i);
            }
        }
    }
}