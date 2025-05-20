using SportsFixture.Dtos.Fixture;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static  class FixtureSubscriptionMapper
    {
        public static SportFixtureDto ToFixtureDto(this SportFixture fixture)
        {
            return fixture switch
            {
                MatchEvent matchEvent => new MatchEventDto
                {
                    Id = matchEvent.Id,
                    EventName = matchEvent.EventName,
                    Referee = matchEvent.Referee,
                    HomeTeamName = matchEvent.HomeTeam?.Name,
                    AwayTeamName = matchEvent.AwayTeam?.Name,
                    StatusShort = matchEvent.StatusShort,
                    EventDateTime = matchEvent.EventDateTime
                },
                MultiTeamEvent multiTeamEvent => new MutliTeamEventDto
                {
                    Id = multiTeamEvent.Id,
                    EventName = multiTeamEvent.EventName,
                    Length = multiTeamEvent.Length,
                    WinningTeamName = multiTeamEvent.WinningTeam?.Name,
                    StatusShort = multiTeamEvent.StatusShort,
                    EventDateTime = multiTeamEvent.EventDateTime
                },
                _ => new SportFixtureDto
                {
                    Id = fixture.Id,
                    EventName = fixture.EventName,
                    StatusShort = fixture.StatusShort,
                    EventDateTime = fixture.EventDateTime
                }
            };
        }
    }
}
