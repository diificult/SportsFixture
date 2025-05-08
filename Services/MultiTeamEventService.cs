using SportsFixture.Dtos.Fixture;
using SportsFixture.Interfaces;
using SportsFixture.Models;

namespace SportsFixture.Services
{
    public class MultiTeamEventService : IEventService<MultiTeamEvent, UpdateMultiTeamEventDto>
    {

        public readonly ISportFixtureBase<MultiTeamEvent> _repository;

        public MultiTeamEventService(ISportFixtureBase<MultiTeamEvent> repo)
        {
            _repository = repo;
        }

        public Task<MultiTeamEvent> AddFixture(MultiTeamEvent fixture)
        {
            return _repository.AddAsync(fixture);
        }

        public Task<MultiTeamEvent?> GetFixtureById(int id)
        {
            return _repository.GetFixtureByIdAsync(id);
        }

        public Task<MatchEvent> UpdateFixture(int id, UpdateMultiTeamEventDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
