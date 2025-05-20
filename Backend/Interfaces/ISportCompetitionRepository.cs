using SportsFixture.Models;

namespace SportsFixture.Interfaces
{
    public interface ISportCompetitionRepository
    {
        Task<SportCompetition> AddCompetition(SportCompetition comp);
        Task<List<SportCompetition>> GetAllCompetitions();
        Task<SportCompetition> GetCompetitionById(int id);

    }
}
