using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_core_new
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }

    public class HelloWorldController : Controller
    {
        [HttpGet("api/helloworld")]
        public object HelloWorld()
        {
            return new
            {
                message = "Hello World",
                time = DateTime.Now
            };
        }

        [HttpGet("helloworld")]
        public ActionResult HelloworldMvc()
        {
            ViewBag.Message = "Hello world!";
            ViewBag.Time = DateTime.Now;

            return View("helloworld");
        }
    }

   

    // public class Startup 
    // {
    //     public void Configure (IApplicationBuilder app) 
    //     {
    //         //First module
    //         app.Use(async (context, next) => {
    //             await context.Response.WriteAsync("\n1. Before - " + DateTime.Now.ToString("mm:ss:ffff"));
    //             await next();
    //             await context.Response.WriteAsync("\n1. After - " + DateTime.Now.ToString("mm:ss:ffff"));
    //         });

    //         //Second module
    //         app.Use(async (context, next) => {
    //             await context.Response.WriteAsync("\n2. Before - " + DateTime.Now.ToString("mm:ss:ffff"));
    //             // await Task.Delay(2000);
    //             await next();
    //             await context.Response.WriteAsync("\n2. After - " + DateTime.Now.ToString("mm:ss:ffff"));
    //         });
            
    //         app.Run(async (context) => {
    //             var length = 0;
    //             using (var client = new HttpClient())
    //             {
    //                 var content = await client.GetStringAsync("https://www.dotnetfoundation.org");
    //                 length = content.Length;
    //             };

    //             await context.Response.WriteAsync("\nNow is: " +  DateTime.Now.ToString("mm:ss:ffff") +" - Length: "+length.ToString());
    //         });
    //     }
    // }

    //Startup class witch MVC
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
           
            // Handler of last Resort
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "Hello World of the last resort. The Time is: " +
                    DateTime.Now.ToString("hh:mm:ss tt"));

            });
        }
    }
}