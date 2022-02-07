using System;
using Microsoft.AspNetCore.Mvc;

namespace WarrantyManager.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            var serviceStatus = new
            {
                ServiceName = "Warranty Manager API",
                Version = "1.0.0",
                SwaggerDocsUrl = "https://"+Request.Host.Value+"/api-docs",
                Date = DateTime.Now.ToShortDateString()
            };
            return Ok(serviceStatus);
        }



        [Route("/api-docs")]
        [HttpGet]
        public IActionResult GetSwagger()
        {
            return Redirect("/swagger");
        }

    }
}
