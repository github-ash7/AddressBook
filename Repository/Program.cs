using Microsoft.AspNetCore.Hosting;

namespace Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                webHost => { webHost.UseStartup<Startup>(); });
    }
}
