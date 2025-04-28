using SportsFixture.Models;

namespace SportsFixture.Interfaces
{
    public interface ISportTeamRepository
    {
        Task<SportTeam> AddTeam(SportTeam team);
        Task<List<SportTeam>> GetAllTeams();
        Task<SportTeam> GetTeamById(int id);
    }
}
