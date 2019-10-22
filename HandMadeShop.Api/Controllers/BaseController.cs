using System.Net;
using HandMadeShop.Api.Utils;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeShop.Api.Controllers
{
    public class BaseController : Controller
    {
        protected new IActionResult Ok()
        {
            return base.Ok(ResponseWrapper.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(ResponseWrapper.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(ResponseWrapper.Error(errorMessage));
        }

        protected IActionResult FromResult(CommandResult commandResult, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (commandResult.IsSuccess && commandResult.Payload != null)
                return StatusCode((int) statusCode, commandResult.Payload);
            return commandResult.IsSuccess ? StatusCode((int) statusCode) : Error(commandResult.Error);
        }
    }
}