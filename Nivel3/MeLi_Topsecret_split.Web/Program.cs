using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MeLi_Topsecret_split.Web
{
    public class Program
    {
        public static IHostingEnvironment HostingEnvironment { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        public static string GcpProjectId { get; private set; }
        public static bool HasGcpProjectId => !string.IsNullOrEmpty(GcpProjectId);

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                ;

            return builder;
        }
     }
}
