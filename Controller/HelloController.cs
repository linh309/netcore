using System;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_new.controller
{
    public class HelloController  : Controller 
    {
        [HttpGet("Hello")]
        public ActionResult HelloMvc() 
        {
            return View("hellomvc");
        }     
        
        [HttpGet("hellojson")]
        public ActionResult HelloJson() 
        {
            return Json(new 
            {
                message = "Hello JSON MVC controler",
                now = DateTime.Now.ToString("mm:ffff")
            });
        }  
    }
}