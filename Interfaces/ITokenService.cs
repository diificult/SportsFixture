using SportsFixture.Models;

namespace SportsFixture.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
