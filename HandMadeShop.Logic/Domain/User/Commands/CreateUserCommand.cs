using HandMadeShop.Dtos.User;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.User.Commands
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserDto NewUserDto { get; set; }

        public CreateUserCommand(CreateUserDto userDto)
        {
            NewUserDto = userDto;
        }
    }
}
