using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Models;

namespace SportsFixture.Repositorys.Subscriptions
{
    public class FixtureSubscriptionRepository : ISubscriptionRepository<FixtureSubscription>
    {
        private readonly ApplicationDbContext _context;

        public FixtureSubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<FixtureSubscription> AddAsync(FixtureSubscription item)
        {
            _context.Set<FixtureSubscription>();
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<FixtureSubscription?> DeleteSubscriptionByIdAsync(int id)
        {
            _context.Set<FixtureSubscription>();
            var subModel = await _context.Set<FixtureSubscription>().FirstOrDefaultAsync(x => x.FixtureId == id);
            if (subModel == null) return null;
            _context.Remove(subModel);
            await _context.SaveChangesAsync();
            return subModel;
        }

        public async Task<FixtureSubscription?> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Set<FixtureSubscription>().FindAsync(id);
        }

        public async Task<List<FixtureSubscription>> GetUserSubscriptionsAsync(AppUser appUser)
        {
            return await _context.Set<FixtureSubscription>().Include(t => t.Fixture).Where(u => u.UserId == appUser.Id).ToListAsync();
        }

    }
}
