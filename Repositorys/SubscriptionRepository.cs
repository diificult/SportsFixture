using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Models;

namespace SportsFixture.Repositorys
{
    public class SubscriptionRepository<T> : ISubscriptionRepository<T> where T : Subscriptions
    {

        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T item)
        {
            _context.Set<T>();
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<T>> GetUserSubscriptions(AppUser appUser)
        {
            return await _context.Set<T>().Include(t => t.Team).Where(u => u.UserId == appUser.Id).ToListAsync();
        }

        public async Task<T?> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    }
}
