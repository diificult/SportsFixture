using SportsFixture.Dtos.Competition;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static class SportCompetitionMapper
    {
        public static SportCompetition ToCompetitionFromDto(this CreateCompetitionDto dto)
        {
            return new SportCompetition
            {
                SportEventName = dto.SportEventName,

            };
        }

    }
}
