using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace dotnet_core_new
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Startup 
    {
        public void Configure (IApplicationBuilder app) 
        {
            var now = DateTime.Now.ToString("t");
            var message = "Now is: " + now;

            app.Run(async (context) =>{
                await context.Response.WriteAsync(message);
            });
        }
    }
}