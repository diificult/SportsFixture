using SportsFixture.Interfaces;
using SportsFixture.Models;

namespace SportsFixture.Services
{
    public class MatchEventService
    {
        public ISportFixtureBase<MatchEvent> _repository;

        public MatchEventService(ISportFixtureBase<MatchEvent> repository)
        {
            _repository = repository;
        }


        public Task<MatchEvent> AddFixture(MatchEvent fixture)
        {
            return _repository.AddAsync(fixture);
        }

        public Task<MatchEvent?> GetFixtureById(int id)
        {
            return _repository.GetFixtureByIdAsync(id);
        }

    }
}
