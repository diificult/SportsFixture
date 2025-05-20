using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Team;
using SportsFixture.Interfaces;
using SportsFixture.Mapper;

namespace SportsFixture.Controllers
{
    [Route("api/SportTeam")]
    public class SportTeamController : ControllerBase
    {

        private readonly ISportTeamRepository _repo;

        public SportTeamController(ISportTeamRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateSportTeamDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teamModel = dto.ToSportTeamFromCreateDto();
            await _repo.AddTeam(teamModel);
            if (teamModel == null) return StatusCode(500, "Couldn't create");
            else return Created();
        }


    }
}
