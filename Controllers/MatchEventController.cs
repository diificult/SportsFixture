using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Fixture;
using SportsFixture.Mapper;
using SportsFixture.Services;

namespace SportsFixture.Controllers
{
    [Route("api/MatchFixture")]
    public class MatchEventController : ControllerBase
    {
        private readonly MatchEventService _service;

        public MatchEventController(MatchEventService service)
        {
            _service = service;
        }



        [HttpPost]
        public async Task<IActionResult> CreateMatchEvent([FromBody] CreateMatchEventDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var fixtureModel = dto.ToSportEventFromCreateDto();
            await _service.AddFixture(fixtureModel);
            return CreatedAtAction(nameof(GetById), new { id = fixtureModel.Id }, fixtureModel);
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fixture = await _service.GetFixtureById(id);
            if (fixture == null)
                return NotFound();

            //To Create a DTO
            return Ok(fixture);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateMatchEvent([FromRoute] int id, [FromBody] UpdateMatchEventDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var fixtureUpdate = await _service.UpdateFixture(id, dto);
            if (fixtureUpdate == null)
            {
                return NotFound();
            }
            return Ok(fixtureUpdate.ToFixtureDto());
        }

    }
}
