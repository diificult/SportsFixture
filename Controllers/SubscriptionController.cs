using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsFixture.Enums;
using SportsFixture.Extensions;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Models;

namespace SportsFixture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly ITeamSubscriptionService _teamSubscriptionService;
        public readonly ICompetitionSubscriptionService _competitonSubscriptionService;
        public readonly IFixtureSubscriptionService _fixtureSubscriptionService;
        


        public SubscriptionController(
            UserManager<AppUser> userManager,
            ITeamSubscriptionService teamSubscriptionService,
            ICompetitionSubscriptionService competitionSubscriptionService,
            IFixtureSubscriptionService fixtureSubscriptionService
            )
        {
            _userManager = userManager;
            _competitonSubscriptionService = competitionSubscriptionService;
            _fixtureSubscriptionService = fixtureSubscriptionService;
            _teamSubscriptionService = teamSubscriptionService;
        }
        
        //TEAMS

        [HttpGet("team")]
        [Authorize]
        public async Task<IActionResult> GetTeamSubscription()
        {
            var username = User.GetUsername();
            var userSubscriptions = await _teamSubscriptionService.GetUserSubscriptionsDto(username);
            return Ok(userSubscriptions);
        }

        [HttpPost("teamId")]
        [Authorize]
        public async Task<IActionResult> AddTeamSubscription(int TeamId)
        {
            var username = User.GetUsername();
            var AddSub = await _teamSubscriptionService.AddSubscription(username, TeamId);
            if (AddSub) return Ok();
            else return BadRequest("Error in adding subscription");
        }
        [HttpPost("teamName")]
        [Authorize]
        public async Task<IActionResult> AddTeamSubscriptionByName(string Team, SportType type)
        {
            var username = User.GetUsername();
            var AddSub = await _teamSubscriptionService.AddSubscriptionByName(username, Team, type);
            if (AddSub) return Ok();
            else return BadRequest("Error in adding subscription");
        }

        [HttpDelete("team")]
        [Authorize]
        public async Task<IActionResult> DeleteTeamSubscriptionByTeamId(int TeamId)
        {
            var username = User.GetUsername();
            var isRemoved = await _teamSubscriptionService.DeleteSubscription(username, TeamId);
            if (isRemoved) return Ok();
            else return BadRequest("Unable to delete subscription");
        }

        //FIXTURES

        [HttpGet("fixture")]
        [Authorize]
        public async Task<IActionResult> GetFixtureSubscription()
        {
            var username = User.GetUsername();
            var userSubsription = await _fixtureSubscriptionService.GetUserSubscriptionsDto(username);
            return Ok(userSubsription);
            
        }
        [HttpPost("fixture")]
        public async Task<IActionResult> AddFixtureSubscription(int fixtureId)
        {
            var username = User.GetUsername();
            var AddSub = await _fixtureSubscriptionService.AddSubscription(username, fixtureId);
            if (AddSub) return Ok();
            else return BadRequest("Error adding subscription");
        }
        [HttpDelete("fixture")]
        [Authorize]
        public async Task<IActionResult> DeleteFixtureSubscriptionByTeamId(int FixtureId)
        {
            var username = User.GetUsername();
            var isRemoved = await _fixtureSubscriptionService.DeleteSubscription(username, FixtureId);
            if (isRemoved) return Ok();
            else return BadRequest("Unable to delete subscription");
        }

        //COMPETITIONS

        [HttpGet("competition")]
        [Authorize]
        public async Task<IActionResult> GetCompetitionSubscription()
        {
            var username = User.GetUsername();
            var userSubsription = await _competitonSubscriptionService.GetUserSubscriptionsDto(username);
            return Ok(userSubsription);

        }
        [HttpPost("competition")]
        public async Task<IActionResult> AddCompetitionSubscription(int competitionId)
        {
            var username = User.GetUsername();
            var AddSub = await _competitonSubscriptionService.AddSubscription(username, competitionId);
            if (AddSub) return Ok();
            else return BadRequest("Error adding subscription");
        }
        [HttpDelete("competition")]
        [Authorize]
        public async Task<IActionResult> DeleteCompetitionSubscriptionByTeamId(int CompetitionId)
        {
            var username = User.GetUsername();
            var isRemoved = await _competitonSubscriptionService.DeleteSubscription(username, CompetitionId);
            if (isRemoved) return Ok();
            else return BadRequest("Unable to delete subscription");
        }
    }
}
