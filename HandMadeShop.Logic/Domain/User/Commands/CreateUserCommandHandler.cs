using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Identity;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.User.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IAsyncDocumentSession _session;
        private readonly SignInManager<Core.DomainEntities.User> _signInManager;
        private readonly UserManager<Core.DomainEntities.User> _userManager;

        public CreateUserCommandHandler(
            IAsyncDocumentSession session,
            UserManager<Core.DomainEntities.User> userManager,
            SignInManager<Core.DomainEntities.User> signInManager)
        {
            _session = session;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<CommandResult> Handle(CreateUserCommand command)
        {
            var newUser = new Core.DomainEntities.User
            {
                UserName = command.NewUserDto.FirstName,
                LastName = command.NewUserDto.LastName,
                Email = command.NewUserDto.Email,
            };

            var createUserResult = await _userManager.CreateAsync(newUser, command.NewUserDto.Password);

            if (!createUserResult.Succeeded)
            {
                var errorString = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
                return await Task.FromResult(CommandResult.Fail(errorString));
            }

            //Add role
            //await _userManager.AddToRoleAsync(newUser, command.NewUserDto.Role);

            // Sign him in and go home.     
            await _signInManager.SignInAsync(newUser, true);
            //await _session.SaveChangesAsync();
            return await Task.FromResult(CommandResult.Ok());
        }
    }
}