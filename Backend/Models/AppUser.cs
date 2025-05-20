using Microsoft.AspNetCore.Identity;

namespace SportsFixture.Models
{
    public class AppUser : IdentityUser
    {

        public List<Subscriptions> Subscriptions { get; set; } = new List<Subscriptions>();
        public string? GoogleCalToken { get; set; } = String.Empty;
    }
}
