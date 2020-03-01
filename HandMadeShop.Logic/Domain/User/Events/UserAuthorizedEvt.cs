using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.User.Events
{
    public class UserAuthorizedEvt : IEvent
    {
        public string UserName { get; set; }
        public string Id { get; set; }
    }
}