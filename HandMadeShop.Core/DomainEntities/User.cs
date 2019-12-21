using Raven.Identity;

namespace HandMadeShop.Infrastrucutre.DomainEntities
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public bool? Gender { get; set; }
    }
}