using Microsoft.AspNetCore.Identity;
using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Mapper;
using SportsFixture.Models;

namespace SportsFixture.Services.Subscription
{
    public class CompeitionSubscriptionService : ICompetitionSubscriptionService
    {

        public readonly UserManager<AppUser> _userManager;
        public readonly ISubscriptionRepository<CompetitionSubscription> _subscriptionRepository;

        public CompeitionSubscriptionService (UserManager<AppUser> userManager, ISubscriptionRepository<CompetitionSubscription> subscriptionRepository)
        {
            _userManager = userManager;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> AddSubscription(string username, int itemId)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            //TODO: Check to see if it already exists, if not get from API.
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            if (userSubscriptions.Any(e => e.CompetitionId == itemId)) return false;
            var competitionModel = new CompetitionSubscription
            {
                CompetitionId = itemId,
                UserId = appUser.Id
            };
            await _subscriptionRepository.AddAsync(competitionModel);
            if (competitionModel == null) return false;
            else return true;

        }

        public async Task<bool> DeleteSubscription(string username, int itemId)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            var filterSubscriptions = userSubscriptions.Where(s => s.CompetitionId == itemId).ToList();
            if (filterSubscriptions.Count() == 1)
            {
                await _subscriptionRepository.DeleteSubscriptionByIdAsync(itemId);
            }
            else return false;
            return true;
        }

        public async Task<List<CompetitionSubscriptionDto>> GetUserSubscriptionsDto(string username)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            var dtos = userSubscriptions.Select(s => s.ToTeamSubscriptionDto()).ToList();

            //return await _subscriptionRepository.GetUserSubscriptions(appUser);
            return dtos;
        } 
    }
}
