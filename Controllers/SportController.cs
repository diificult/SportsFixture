using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Competition;
using SportsFixture.Dtos.Sport;
using SportsFixture.Interfaces;
using SportsFixture.Mapper;
using SportsFixture.Repositorys;

namespace SportsFixture.Controllers
{
    [Route("api/Sport")]
    public class SportController : ControllerBase
    {

        public readonly ISportsRepository _repo;

        public SportController(ISportsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSport([FromBody] CreateSportDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sportModel = dto.ToSportFromCreateDto();
            await _repo.AddSport(sportModel);
            if (sportModel == null) return StatusCode(500, "Couldn't create");
            else return Created();
        }
    }
}
