using HandMadeShop.Api.Utils;
using HandMadeShop.Domain.Utils;
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

        protected IActionResult FromResult(CommandResult commandResult)
        {
            return commandResult.IsSuccess ? Ok() : Error(commandResult.Error);
        }
    }
}