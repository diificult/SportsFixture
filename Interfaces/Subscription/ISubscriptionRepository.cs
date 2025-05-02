using SportsFixture.Models;

namespace SportsFixture.Interfaces.Subscription
{
    public interface ISubscriptionRepository<T> where T : Subscriptions
    {
        Task<T> AddAsync(T item);

        Task<List<T>> GetUserSubscriptions(AppUser appUser);

        Task<T?> GetSubscriptionByIdAsync(int id);


    }
}
