using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces;
using SportsFixture.Models;

namespace SportsFixture.Repositorys
{
    public class SportsRepository : ISportsRepository
    {

        private readonly ApplicationDbContext _context;

        public SportsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Sport> AddSport(Sport sport)
        {
            await _context.AddAsync(sport);
            await _context.SaveChangesAsync();
            return sport;
        }

        public async Task<List<Sport>> GetAllSports()
        {
            return await _context.Sports.ToListAsync();
        }

        public async Task<Sport> GetSportById(int id)
        {
            return await _context.Sports.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
