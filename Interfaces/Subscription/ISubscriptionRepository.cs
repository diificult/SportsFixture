using SportsFixture.Models;

namespace SportsFixture.Interfaces.Subscription
{
    public interface ISubscriptionRepository<T> where T : Subscriptions
    {
        Task<T> AddAsync(T item);

        Task<List<T>> GetUserSubscriptionsAsync(AppUser appUser);

        Task<T?> GetSubscriptionByIdAsync(int id);

        Task<T?> DeleteSubscriptionByIdAsync(int id);

    }
}
