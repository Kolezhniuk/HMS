using System.Threading.Tasks;
using HandMadeShop.Api.Utils;
using HandMadeShop.Dtos.User;
using HandMadeShop.Logic.Domain.User.Commands;
using HandMadeShop.Logic.Domain.User.Events;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HandMadeShop.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(MessageBus messageBus, ILogger logger) : base(messageBus, logger)
        {
        }

        [HttpPost("create-user")]
        public Task<ApiResponse<bool>> CreateUser(CreateUserDto userDto)
        {
            return Catch(async () =>
            {
                var command = new CreateUserCommand(userDto);
                await MessageBus.DispatchCommand(command);
                return true;
            });
        }

        // [Authorize]
        [HttpGet("Authorize_Test")]
        public async Task<IActionResult> AuthorizeOnly()
        {
            await MessageBus.PublishEvent(new UserAuthorizedEvt {Id = "user id", UserName = "Dimasik"});
            return Ok();
        }
    }
}