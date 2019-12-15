using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HandMadeShop.Api.Extensions;
using HandMadeShop.Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HandMadeShop.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController(ILogger logger)
        {
            Logger = logger;
        }

        protected ILogger Logger { get; }

        protected IActionResult Ok<T>(T result) => base.Ok(new ApiResponse<T>(result));

        protected IActionResult Error(string errorMessage) =>
            BadRequest(new ApiException(HttpStatusCode.BadRequest, errorMessage));

        protected async Task<ApiResponse<T>> Catch<T>(Func<Task<T>> action, [CallerFilePath] string file = null,
            [CallerMemberName] string member = null, [CallerLineNumber] int line = 0)
        {
            try
            {
                return new ApiResponse<T>(await action());
            }
            catch (ApiException e)
            {
                Logger.Error(e, file, member, line);
                return new ApiResponse<T>(e.Status, e.Message);
            }
            catch (Exception e)
            {
                Logger.Error(e, file, member, line);
                return new ApiResponse<T>(HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        protected async Task Catch(Func<Task> action, [CallerFilePath] string file = null,
            [CallerMemberName] string member = null, [CallerLineNumber] int line = 0)
        {
            try
            {
                await action();
            }
            catch (ApiException e)
            {
                Logger.Error(e, file, member, line);
            }
            catch (Exception e)
            {
                Logger.Error(e, file, member, line);
            }
        }

        protected void ThrowIfModelInvalid()
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(HttpStatusCode.BadRequest,
                    $"Model is invalid! Error: {ModelState.GetDebugError()}");
            }
        }
    }
}