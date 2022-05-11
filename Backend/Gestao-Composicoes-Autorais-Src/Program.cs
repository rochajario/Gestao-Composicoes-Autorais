using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Gestao_Composicoes_Autorais_Src
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
