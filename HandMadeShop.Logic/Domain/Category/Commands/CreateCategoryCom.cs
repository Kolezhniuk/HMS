using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Infrastrucutre.Domain.Category.Commands
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