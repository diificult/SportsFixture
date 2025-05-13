using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Enums;
using SportsFixture.Interfaces;
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
        public readonly ISportTeamRepository _teamRepository;
        public readonly SportServiceFactory _sportService;

        public TeamSubscriptionService (UserManager<AppUser> userManager, ISubscriptionRepository<TeamSubscription> subscriptionRepository, ISportTeamRepository teamRepository, SportServiceFactory sportService)
        {
            _userManager = userManager;
            _subscriptionRepository = subscriptionRepository;
            _teamRepository = teamRepository;
            _sportService = sportService;      
        }

        public async Task<bool> AddSubscription(string username, int itemId)
        {
            var appUser = await _userManager.FindByNameAsync(username);
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


        public async Task<bool> AddSubscriptionByName(string username, string teamName, SportType type)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            var team = _teamRepository.GetTeamByName(teamName).Result;
            if (team == null)
            {
                var service = _sportService.GetTeamService(type);
                var teams = await service.getTeamByName(teamName);
               
                if (teams == null) return false;
                else
                {
                    //Stores all results to reduce future requests
                    foreach (SportTeam t in teams)
                    {
                        Console.WriteLine($"Also stored: {t.Name}");
                        await _teamRepository.AddTeam(t);

                    }
                    team = teams[0];
                }

            }
            var userSubscriptions = await _subscriptionRepository.GetUserSubscriptionsAsync(appUser);
            if (userSubscriptions.Any(e => e.Team.Name == teamName)) return false;
            var teamModel = new TeamSubscription
            {
                TeamId = team.Id,
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
