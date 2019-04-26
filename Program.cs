using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace dotnet_core_new
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
                        
            host.Run();
        }
    }

    public class Startup 
    {
        public void Configure (IApplicationBuilder app) 
        {
            //First module
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("\n1. Before - " + DateTime.Now.ToString("mm:ss:ffff"));
                await next();
                await context.Response.WriteAsync("\n1. After - " + DateTime.Now.ToString("mm:ss:ffff"));
            });

            //Second module
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("\n2. Before - " + DateTime.Now.ToString("mm:ss:ffff"));
                // await Task.Delay(2000);
                await next();
                await context.Response.WriteAsync("\n2. After - " + DateTime.Now.ToString("mm:ss:ffff"));
            });
            
            app.Run(async (context) => {
                var length = 0;
                using (var client = new HttpClient())
                {
                    var content = await client.GetStringAsync("https://www.dotnetfoundation.org");
                    length = content.Length;
                };

                await context.Response.WriteAsync("\nNow is: " +  DateTime.Now.ToString("mm:ss:ffff") +" - Length: "+length.ToString());
            });
        }
    }
}