/*********************************************************
       Code Generated By  .  .  .  .  Delaney's Script Bot
       WWW .  .  .  .  .  .  .  .  .  www.scriptbot.io
       Version.  .  .  .  .  .  .  .  10.0.0.14 
       Build  .  .  .  .  .  .  .  .  20191113 216
       Template Name.  .  .  .  .  .  Project Green 2.0
       Template Version.  .  .  .  .  20191111 001
       Author .  .  .  .  .  .  .  .  Delaney

                          .___,
                       ___('v')___
                       `"-\._./-"'
                           ^ ^

 *********************************************************/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Delaney
{
    public class Program
    {
        public static void Main(string[] args)
        {
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