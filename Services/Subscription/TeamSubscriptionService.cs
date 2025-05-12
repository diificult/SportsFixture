using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Mapper;
using SportsFixture.Models;
using System.Reflection.Metadata.Ecma335;

namespace SportsFixture.Services.Subscription
{
    public class TeamSubscriptionService : ITeamSubscriptionService
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
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
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

        public async Task<bool> DeleteSubscription(string username, int itemId)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            var filterSubscriptions = userSubscriptions.Where(s => s.TeamId == itemId).ToList();
            if (filterSubscriptions.Count() == 1)
            {
                await _subscriptionRepository.DeleteSubscriptionByIdAsync(itemId);
            }
            else return false;
            return true;
        }   

        public async Task<List<TeamSubscriptionDto>> GetUserSubscriptionsDto(string username)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            var dtos = userSubscriptions.Select(s => s.ToTeamSubscriptionDto()).ToList();

            //return await _subscriptionRepository.GetUserSubscriptions(appUser);
            return dtos;
        } 
    }
}
