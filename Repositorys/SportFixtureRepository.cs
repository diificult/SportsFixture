using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces;

namespace SportsFixture.Repositorys
{
    public class SportFixtureRepository<T> : ISportFixtureBase<T> where T : class
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
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
