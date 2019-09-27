using System;
using CSharpFunctionalExtensions;
using HandMadeShop.Api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeShop.Api.Controllers
{
    public class BaseController: Controller
    {
        protected new IActionResult Ok()
        {
            return base.Ok(ResponceWrapper.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(ResponceWrapper.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(ResponceWrapper.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }
    }
}