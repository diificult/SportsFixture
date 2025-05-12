using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Models;

namespace SportsFixture.Repositorys.Subscriptions
{
    public class TeamSubscriptionRepository : ISubscriptionRepository<TeamSubscription>
    {
        private readonly ApplicationDbContext _context;

        public TeamSubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<TeamSubscription> AddAsync(TeamSubscription item)
        {
            _context.Set<TeamSubscription>();
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<TeamSubscription?> DeleteSubscriptionByIdAsync(int id)
        {
            _context.Set<TeamSubscription>();
            var subModel = await _context.Set<TeamSubscription>().FirstOrDefaultAsync(x => x.TeamId == id);
            if (subModel == null) return null;
            _context.Remove(subModel);
            await _context.SaveChangesAsync();
            return subModel;
        }

        public async Task<TeamSubscription?> GetSubscriptionByIdAsync(int id)
        {
            return await _context.Set<TeamSubscription>().FindAsync(id);
        }

        public async Task<List<TeamSubscription>> GetUserSubscriptionsAsync(AppUser appUser)
        {
            return await _context.Set<TeamSubscription>().Include(t => t.Team).Where(u => u.UserId == appUser.Id).ToListAsync();
        }
    }
}
