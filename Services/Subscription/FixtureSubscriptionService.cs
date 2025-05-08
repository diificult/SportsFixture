using Microsoft.AspNetCore.Identity;
using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Mapper;
using SportsFixture.Models;

namespace SportsFixture.Services.Subscription
{
    public class FixtureSubscriptionService : IFixtureSubscriptionService
    {

        public readonly UserManager<AppUser> _userManager;
        public readonly ISubscriptionRepository<FixtureSubscription> _subscriptionRepository;

        public FixtureSubscriptionService(UserManager<AppUser> userManager, ISubscriptionRepository<FixtureSubscription> subscriptionRepository)
        {
            _userManager = userManager;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> AddSubscription(string username, int itemId)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            //TODO: Check to see if it already exists, if not get from API.
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            if (userSubscriptions.Any(e => e.FixtureId == itemId)) return false;
            var fixtureModel = new FixtureSubscription
            {
                FixtureId = itemId,
                UserId = appUser.Id
            };
            await _subscriptionRepository.AddAsync(fixtureModel);
            if (fixtureModel == null) return false;
            else return true;

        }

        public async Task<List<FixtureSubscriptionDto>?> GetUserSubscriptionsDto(string username)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            // var dtos = userSubscriptions.Select(s => s.ToTeamSubscriptionDto()).ToList();

            var dtos = userSubscriptions.Select(s => new FixtureSubscriptionDto
            {
                id = s.Id,
                fixture = s.Fixture.ToFixtureDto(),
            }).ToList();
            
            //return await _subscriptionRepository.GetUserSubscriptions(appUser);
            return dtos;
        } 
    }
}
