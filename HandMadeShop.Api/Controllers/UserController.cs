using System.Threading.Tasks;
using HandMadeShop.Api.Utils;
using HandMadeShop.Dtos.User;
using HandMadeShop.Infrastructure.Messaging;
using HandMadeShop.Infrastrucutre.Domain.User.Commands;
using HandMadeShop.Logic.Domain.User.Events;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HandMadeShop.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly EventBus _eventBus;

        public UserController(MessageBus messageBus, ILogger logger, EventBus eventBus) : base(messageBus, logger)
        {
            _eventBus = eventBus;
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

        [Authorize]
        [HttpGet("Authorize_Test")]
        public async Task<IActionResult> AuthorizeOnly()
        {
            _eventBus.PublishEvent(new UserAuthorizedEvt {Id = "user id", Name = "Dima", UserName = "Dimasik"});
            return await Task.FromResult(Ok());
        }
    }
}