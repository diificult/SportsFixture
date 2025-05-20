using SportsFixture.Models;

namespace SportsFixture.Interfaces
{
    public interface ISportFixtureBase<T> where T : SportFixture
    {
        Task<T> AddAsync(T item);
        Task<T?> GetFixtureByIdAsync(int id);
        
        Task<List<T>> GetAllFixtures();

        Task<T> UpdateFixtureAsync(T item, int id);
        
    }
}
