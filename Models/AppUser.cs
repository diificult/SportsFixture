using Microsoft.AspNetCore.Identity;

namespace SportsFixture.Models
{
    public class AppUser : IdentityUser
    {

        List<SportTeam> FollowedTeams { get; set; } = new List<SportTeam>();
    }
}
