using Microsoft.JSInterop.Infrastructure;
using SportsFixture.Dtos.Fixture;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static class SportEventMapper
    {

        public static MatchEvent ToSportEventFromCreateDto(this CreateMatchEventDto dto)
        {
            return new MatchEvent
            {
                EventDateTime = dto.EventDateTime,
                EventName = dto.EventName,
                Referee = dto.Referee,
                StatusShort = dto.StatusShort,
                SportCompetitionId = dto.SportCompetitionId,
                Location = dto.Location,
                SportId = dto.SportId,
                HomeResult = dto.HomeResult,
                AwayResults = dto.AwayResults,
                HomeTeamId = dto.HomeTeamId,
                AwayTeamId = dto.AwayTeamId,

            };
        }

    }
}
