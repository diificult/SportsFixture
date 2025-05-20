using SportsFixture.Dtos.Fixture;
using SportsFixture.Interfaces;
using SportsFixture.Mapper;
using SportsFixture.Models;

namespace SportsFixture.Services
{
    public class MatchEventService : IEventService<MatchEvent, UpdateMatchEventDto>
    {
        public readonly ISportFixtureBase<MatchEvent> _repository;

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

        public Task<MatchEvent> UpdateFixture(int id, UpdateMatchEventDto dto)
        {
            var fixture = dto.ToMatchEventFromUpdateDto(id);
            return _repository.UpdateFixtureAsync(fixture, id);
        }
    }
}
