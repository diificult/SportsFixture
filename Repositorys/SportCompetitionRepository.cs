using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces;
using SportsFixture.Models;

namespace SportsFixture.Repositorys
{
    public class SportCompetitionRepository : ISportCompetitionRepository
    {

        private readonly ApplicationDbContext _context;

        public SportCompetitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SportCompetition> AddCompetition(SportCompetition comp)
        {
            await _context.AddAsync(comp);
            await _context.SaveChangesAsync();
            return comp;
        }

        public async Task<List<SportCompetition>> GetAllCompetitions()
        {
            return await _context.SportCompetition.ToListAsync();
        }

        public async Task<SportCompetition> GetCompetitionById(int id)
        {
            return await _context.SportCompetition.FirstOrDefaultAsync(c => c.SportEventID == id);
        }
    }
}
