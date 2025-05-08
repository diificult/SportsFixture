
using Microsoft.AspNetCore.Mvc;
using SportsFixture.Dtos.Subscriptions;

namespace SportsFixture.Interfaces.Subscription
{
    public interface ITeamSubscriptionService
    {
        Task<List<TeamSubscriptionDto>> GetUserSubscriptionsDto(string username);
        Task<bool> AddSubscription(string username, int itemId);
        Task<bool> DeleteSubscription(string username, int itemId);
    }
}
