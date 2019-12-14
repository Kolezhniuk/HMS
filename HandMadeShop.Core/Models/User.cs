using Raven.Identity;

namespace HandMadeShop.Core.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public bool? Gender { get; set; }
    }
}