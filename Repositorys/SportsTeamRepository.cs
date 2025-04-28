using Microsoft.EntityFrameworkCore;
using SportsFixture.Data;
using SportsFixture.Interfaces;
using SportsFixture.Models;

namespace SportsFixture.Repositorys
{
    public class SportsTeamRepository : ISportTeamRepository
    {

        private readonly ApplicationDbContext _context;

        public SportsTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SportTeam> AddTeam(SportTeam team)
        {
            await _context.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<List<SportTeam>> GetAllTeams()
        {
            return await _context.SportTeams.ToListAsync();
        }

        public async Task<SportTeam> GetTeamById(int id)
        {
            return await _context.SportTeams.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
