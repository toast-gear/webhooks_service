using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using webhooks_service.Singletons;

namespace webhooks_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Start instance of our HttpClient on launch
            HttpClientSingleton HttpClient = HttpClientSingleton.Instance();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
