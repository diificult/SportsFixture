using SportsFixture.Models;

namespace SportsFixture.Interfaces
{
    public interface ISportsRepository
    {
        Task<Sport> AddSport(Sport team);
        Task<List<Sport>> GetAllSports();
        Task<Sport> GetSportById(int id);
    }
}
