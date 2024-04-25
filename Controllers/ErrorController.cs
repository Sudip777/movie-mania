/*
 * Since we are using minimal api for error handling this is not needed 
 * 
 * 
 * 
 * using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase

    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }

        [Route("/error/test")]
        [HttpGet]
        public IActionResult Test()
        {
           throw new Exception("test");
        }

        
    }

}
*/