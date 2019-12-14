using System.Threading.Tasks;
using HandMadeShop.Dtos.User;
using HandMadeShop.Logic.Domain.User.Commands;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeShop.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly Messages _messages;

        public UserController(Messages messages)
        {
            _messages = messages;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var command = new CreateUserCommand(userDto);
            var result = await _messages.DispatchCommand(command);
            return FromResult(result);
        }

        [Authorize]
        [HttpGet("Authorize_Test")]
        public async Task<IActionResult> AuthorizeOnly()
        {
            return await Task.FromResult(Ok());
        }

        //Just for test
        //[HttpPost("test")]
        //public async Task<IActionResult> TestAddUser()
        //{
        //    var createUserDto = new CreateUserDto()
        //    {
        //        FirstName = "Sem",
        //        LastName = "Mat",
        //        Email = "Mat1@gmail.com",
        //        Password = "Mat1@gmail.com"
        //    };
        //
        //    var command = new CreateUserCommand(createUserDto);
        //    var result = await _messages.DispatchCommand(command);
        //    return FromResult(result);
        //}
    }
}