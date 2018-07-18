using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace velocity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseEnvironment("Production")
                //.UseEnvironment("Development")
                .UseKestrel()
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
