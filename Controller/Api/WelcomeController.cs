using System;
using Microsoft.AspNetCore.Mvc;

public class WelcomeController
    {
        [HttpGet("api/hello")]
        public object Hello()
        {
            return new 
            {
                message = "Hello from dedicated controller",
                now = DateTime.Now.ToString("mm:ffff")
            };
        }
    }