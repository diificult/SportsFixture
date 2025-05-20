using SportsFixture.Dtos.Team;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static class SportTeamMapper
    {

        public static SportTeam ToSportTeamFromCreateDto(this CreateSportTeamDto dto)
        {
            return new SportTeam { 
                SportId = dto.SportId,
                Name = dto.Name,
                APIid = dto.APIid,
            };
        } 
        public static SportTeam ToSportTeamFromapiFootball(this Response apiTeam)
        {
            return new SportTeam
            {
                SportId = 1,
                Name = apiTeam.team.name,
                APIid = apiTeam.team.id,
            };
        }
    }
}
