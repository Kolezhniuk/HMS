namespace HandMadeShop.Core.Models
{
    public class AppUser : Raven.Identity.IdentityUser
    {
        public string LastName { get; set; }
        public bool? Gender { get; set; }
    }
}