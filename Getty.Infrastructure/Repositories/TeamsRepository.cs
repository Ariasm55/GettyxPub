using Getty.Core.Entities;
using Getty.Core.Interfaces;
using Getty.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Getty.Infrastructure.Repositories
{
    public  class TeamsRepository : ITeamsRepository
    {
        private readonly GettyContext _context;

        public TeamsRepository(GettyContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<TmsTeam>> GetTeams()
        {
            var teams = await _context.TmsTeams.ToListAsync();

            return teams;
        }

        public async Task<TmsTeam> GetTeam(int id)
        {
            var team = await _context.TmsTeams.FirstOrDefaultAsync(x => x.TmsId == id );

            return team;
        }

        public async Task NewTeam(TmsTeam Team)
        {
            _context.TmsTeams.Add(Team);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> DeleteTeam(int TeamID)
        {
            var team = await GetTeam(TeamID);
            _context.TmsTeams.Remove(team);

            int rows = await _context.SaveChangesAsync();

            //return true if rows were affected
            return rows > 0;
        }

        public async Task<bool> UpdateTeam(TmsTeam Team)
        {
            var currentTeam = await GetTeam(Team.TmsId);
            currentTeam.TmsDescription = Team.TmsDescription;
            currentTeam.TmsCampId = Team.TmsCampId;
           
            int rows = await _context.SaveChangesAsync();

            //return true if rows were affected
            return rows > 0;

        }


    }
}
