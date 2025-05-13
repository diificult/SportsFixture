using SportsFixture.Models;

namespace SportsFixture.Interfaces
{
    public interface IapiSportService
    {
        Task<List<SportTeam>> getTeamByName(string name);
    }
}
