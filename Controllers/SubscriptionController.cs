using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public readonly ICompetitionSubscriptionService _competitonRepository;
        public readonly IFixtureSubscriptionService _fixtureRepository;
        


        public SubscriptionController(
            UserManager<AppUser> userManager,
            ITeamSubscriptionService teamSubscriptionService,
            ICompetitionSubscriptionService competitionSubscriptionService,
            IFixtureSubscriptionService fixtureSubscriptionService
            )
        {
            _userManager = userManager;
            _competitonRepository = competitionSubscriptionService;
            _fixtureRepository = fixtureSubscriptionService;
            _teamSubscriptionService = teamSubscriptionService;
        }

        [HttpGet("team")]
        [Authorize]
        public async Task<IActionResult> GetTeamSubscription()
        {
            var username = User.GetUsername();
            var userSubscriptions = await _teamSubscriptionService.GetUserSubscriptionsDto(username);
            return Ok(userSubscriptions);
        }

        [HttpPost("team")]
        [Authorize]
        public async Task<IActionResult> AddTeamSubscription(int TeamId)
        {
            var username = User.GetUsername();
            var AddSub = await _teamSubscriptionService.AddSubscription(username, TeamId);
            if (AddSub) return Ok();
            else return BadRequest("Error in adding subscription");
        }
        [HttpGet("fixture")]
        [Authorize]
        public async Task<IActionResult> GetFixtureSubscription()
        {
            var username = User.GetUsername();
            var userSubsription = await _fixtureRepository.GetUserSubscriptionsDto(username);
            return Ok(userSubsription);
            
        }
        [HttpPost("fixture")]
        public async Task<IActionResult> AddFixtureSubscription(int fixtureId)
        {
            var username = User.GetUsername();
            var AddSub = await _fixtureRepository.AddSubscription(username, fixtureId);
            if (AddSub) return Ok();
            else return BadRequest("Error adding subscription");
        }

        [HttpGet("competition")]
        [Authorize]
        public async Task<IActionResult> GetCompetitionSubscription()
        {
            var username = User.GetUsername();
            var userSubsription = await _competitonRepository.GetUserSubscriptionsDto(username);
            return Ok(userSubsription);

        }
        [HttpPost("competition")]
        public async Task<IActionResult> AddCompetitionSubscription(int competitionId)
        {
            var username = User.GetUsername();
            var AddSub = await _competitonRepository.AddSubscription(username, competitionId);
            if (AddSub) return Ok();
            else return BadRequest("Error adding subscription");
        }
    }
}
