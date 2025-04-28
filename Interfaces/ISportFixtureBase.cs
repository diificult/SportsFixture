using System.Runtime.CompilerServices;

namespace SportsFixture.Interfaces
{
    public interface ISportFixtureBase<T> where T : class
    {
        Task<T> AddAsync(T item);
        Task<T?> GetFixtureByIdAsync(int id);
        Task<List<T>> GetAllFixtures();
        
    }
}
