using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces;
using SportsFixture.Models;

namespace SportsFixture.Repositorys
{
    public class SportFixtureRepository<T> : ISportFixtureBase<T> where T : SportFixture
    {

        private readonly ApplicationDbContext _context;

        public  SportFixtureRepository (ApplicationDbContext context)
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

        public async Task<List<T>> GetAllFixtures()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetFixtureByIdAsync(int id)
        {
            return await _context.Set<T>().Include(s => s.Sport).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<T?> UpdateFixtureAsync(T updatedFixture, int id)
        {
            var existingFixture = await _context.Set<T>().FirstOrDefaultAsync(f => f.Id == id);
            if (existingFixture == null) return null;
            _context.Entry(existingFixture).CurrentValues.SetValues(updatedFixture);

            await _context.SaveChangesAsync();
            return existingFixture;
        }
    }
}
