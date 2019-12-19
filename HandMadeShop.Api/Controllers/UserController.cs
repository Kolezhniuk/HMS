using System.Threading.Tasks;
using HandMadeShop.Api.Utils;
using HandMadeShop.Dtos.User;
using HandMadeShop.Logic.Domain.User.Commands;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HandMadeShop.Api.Controllers
{
    public class UserController : BaseController
    {
        public UserController(Messages messages, ILogger logger) : base(messages, logger)
        {
        }

        [HttpPost("create-user")]
        public Task<ApiResponse<bool>> CreateUser(CreateUserDto userDto)
            => Catch(async () =>
            {
                var command = new CreateUserCommand(userDto);
                await _messages.DispatchCommand(command);
                return true;
            });

        [Authorize]
        [HttpGet("Authorize_Test")]
        public async Task<IActionResult> AuthorizeOnly()
        {
            return await Task.FromResult(Ok());
        }
    }
}