using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Rentacar.API.Controllers
{
    [Route("error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            // Handle specific exceptions
            if (exception is ArgumentException)
            {
                return BadRequest("Please resolve the issues with request");
            }

            // Default behavior
            return StatusCode(500, "Something went wrong! Please try again later...");
        }
    }
}
