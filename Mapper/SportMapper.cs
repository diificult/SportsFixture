using SportsFixture.Dtos.Sport;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static class SportMapper
    {

        public static Sport ToSportFromCreateDto(this CreateSportDto dto)
        {
            return new Sport
            {
                Name = dto.SportName,
            };
        }
    }
}
