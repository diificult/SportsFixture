using Microsoft.AspNetCore.Identity;
using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Mapper;
using SportsFixture.Models;

namespace SportsFixture.Services.Subscription
{
    public class TeamSubscriptionService : ISubscriptionService<TeamSubscription>
    {

        public readonly UserManager<AppUser> _userManager;
        public readonly ISubscriptionRepository<TeamSubscription> _subscriptionRepository;

        public TeamSubscriptionService (UserManager<AppUser> userManager, ISubscriptionRepository<TeamSubscription> subscriptionRepository)
        {
            _userManager = userManager;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> AddSubscription(string username, int itemId)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            //TODO: Check to see if it already exists, if not get from API.
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptions(appUser);
            if (userSubscriptions.Any(e => e.TeamId == itemId)) return false;
            var teamModel = new TeamSubscription
            {
                TeamId = itemId,
                UserId = appUser.Id
            };
            await _subscriptionRepository.AddAsync(teamModel);
            if (teamModel == null) return false;
            else return true;

        }

        public async Task<List<TeamSubscriptionDto>> GetUserSubscriptionsDto(string username)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptions(appUser);
            var dtos = userSubscriptions.Select(s => s.ToTeamSubscriptionDto()).ToList();

            //return await _subscriptionRepository.GetUserSubscriptions(appUser);
            return dtos;
        }

        public async Task<List<TeamSubscription>> GetUserSubscriptions(string username)
        {
            throw new NotImplementedException();
        }
    }
}
