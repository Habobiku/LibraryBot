using LibraryBot;
using LibraryBot.TGBot;

namespace LibraryBot
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Bot.Get();

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