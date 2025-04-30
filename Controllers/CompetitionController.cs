using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Competition;
using SportsFixture.Interfaces;
using SportsFixture.Mapper;

namespace SportsFixture.Controllers
{
    [Route("api/Competition")]
    public class CompetitionController : ControllerBase
    {
        private readonly ISportCompetitionRepository _repo;
       public CompetitionController(ISportCompetitionRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetition([FromBody] CreateCompetitionDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var compModel = dto.ToCompetitionFromDto();
            await _repo.AddCompetition(compModel);
            if (compModel == null) return StatusCode(500, "Couldn't create");
            else return Created();
        }



    }
}
