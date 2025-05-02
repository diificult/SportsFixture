using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsFixture.Extensions;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Models;
using SportsFixture.Services.Subscription;

namespace SportsFixture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly ISubscriptionService<TeamSubscription> _teamSubscriptionService;
        public readonly ISubscriptionRepository<CompetitionSubscription> _competitonRepository;
        public readonly ISubscriptionRepository<FixtureSubscription> _fixtureRepository;
        


        public SubscriptionController(
            UserManager<AppUser> userManager, 
            ISubscriptionRepository<CompetitionSubscription> compRepo, 
            ISubscriptionRepository<FixtureSubscription> fixtureRepo,
            ISubscriptionService<TeamSubscription> teamSubscriptionService)
        {
            _userManager = userManager;
            _competitonRepository = compRepo;
            _fixtureRepository = fixtureRepo;
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTeamSubscription(int TeamId)
        {
            var username = User.GetUsername();
            var AddSub = await _teamSubscriptionService.AddSubscription(username, TeamId);
            if (AddSub) return Ok();
            else return BadRequest("Error in adding subscription");
        }
    }
}
