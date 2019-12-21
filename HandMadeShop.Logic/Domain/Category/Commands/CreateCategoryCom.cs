using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Category.Commands
{
    public sealed class CreateCategoryCommand : ICommand
    {
        public CreateCategoryCommand(string prop)
        {
            PROP = prop;
        }

        public string PROP { get; }
    }
}