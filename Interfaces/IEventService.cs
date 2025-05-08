using SportsFixture.Dtos.Fixture;
using SportsFixture.Models;

namespace SportsFixture.Interfaces
{
    public interface IEventService<T, Z> where T : SportFixture where Z : UpdateFixtureDto
    {
        public Task<T> AddFixture(T fixture);
        public Task<T?> GetFixtureById(int id);
        public Task<MatchEvent> UpdateFixture(int id, Z dto);
    }
}
