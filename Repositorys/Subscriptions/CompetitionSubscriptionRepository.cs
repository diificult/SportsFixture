using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Models;

namespace SportsFixture.Repositorys.Subscriptions
{
    public class CompetitionSubscriptionRepository : ISubscriptionRepository<CompetitionSubscription>
    {
        private readonly ApplicationDbContext _context;

        public CompetitionSubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<CompetitionSubscription> AddAsync(CompetitionSubscription item)
        {
            _context.Set<CompetitionSubscription>();
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<CompetitionSubscription?> DeleteSubscriptionByIdAsync(int id)
        {
            _context.Set<CompetitionSubscription>();
            var subModel = await _context.Set<CompetitionSubscription>().FirstOrDefaultAsync(x => x.CompetitionId == id);
            if (subModel == null) return null;
            _context.Remove(subModel);
            await _context.SaveChangesAsync();
            return subModel;
        }

        public async Task<CompetitionSubscription?> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Set<CompetitionSubscription>().FindAsync(id);
        }

        public async Task<List<CompetitionSubscription>> GetUserSubscriptionsAsync(AppUser appUser)
        {
            return await _context.Set<CompetitionSubscription>().Include(t => t.Competition).Where(u => u.UserId == appUser.Id).ToListAsync();
        }
    }
}
