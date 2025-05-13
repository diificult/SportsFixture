
using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Enums;

namespace SportsFixture.Interfaces.Subscription
{
    public interface ITeamSubscriptionService
    {
        Task<List<TeamSubscriptionDto>> GetUserSubscriptionsDto(string username);
        Task<bool> AddSubscription(string username, int itemId);
        Task<bool> AddSubscriptionByName(string username, string teamName, SportType type);
        Task<bool> DeleteSubscription(string username, int itemId);
    }
}
