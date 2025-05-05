using SportsFixture.Dtos.Fixture;
using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static  class FixtureSubscriptionMapper
    {
        public static SportFixtureDto ToFixtureDto(SportFixture fixture)
        {
            return fixture switch
            {
                MatchEvent m => new MatchEventDto
                {
                    Id = m.Id,
                    EventName = m.EventName,
                    Referee = m.Referee,
                    HomeTeamName = m.HomeTeam?.Name,
                    AwayTeamName = m.AwayTeam?.Name,
                    StatusShort = m.StatusShort,
                    EventDateTime = m.EventDateTime
                },
                MultiTeamEvent mt => new MutliTeamEventDto
                {
                    Id = mt.Id,
                    EventName = mt.EventName,
                    Length = mt.Length,
                    WinningTeamName = mt.WinningTeam?.Name,
                    StatusShort = mt.StatusShort,
                    EventDateTime = mt.EventDateTime
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
