using HandMadeShop.Core;

namespace HandMadeShop.Logic.Domain.User.Events
{
    public class UserAuthorizedEvt : DomainEvent
    {
        public string UserName { get; set; }
    }
}