using SportsFixture.Dtos.Subscriptions;

namespace SportsFixture.Interfaces.Subscription
{
    public interface IFixtureSubscriptionService
    {
        Task<List<FixtureSubscriptionDto>> GetUserSubscriptionsDto(string username);
        Task<bool> AddSubscription(string username, int itemId);
        Task<bool> DeleteSubscription(string username, int itemId);
    }
}
