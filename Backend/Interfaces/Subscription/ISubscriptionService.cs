using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Models;

namespace SportsFixture.Interfaces.Subscription
{
    public interface ISubscriptionService<T> where T : Subscriptions
    {
        Task<List   <T>> GetUserSubscriptions(string username);
        Task<List<TeamSubscriptionDto>> GetUserSubscriptionsDto(string username);
        Task<bool> AddSubscription(string username, int itemId);
    }
}
