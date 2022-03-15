using Getty.Core.Entities;
using Getty.Core.Interfaces;
using GettyX.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Core.Services
{
    public  class TeamService : ITeamsService
    {
        private readonly ITeamsRepository _Teamrepository;

        public TeamService(ITeamsRepository Teamrepository)
        {
            _Teamrepository = Teamrepository;   
        }

        public async Task<bool> DeleteTeam(int TeamID)
        {
            return await _Teamrepository.DeleteTeam(TeamID);
        }

        public async Task<TmsTeam> GetTeam(int id)
        {
            return await _Teamrepository.GetTeam(id);   
        }

        public async Task<IEnumerable<TmsTeam>> GetTeams()
        {
            return await _Teamrepository.GetTeams();
        }

        public async Task NewTeam(TmsTeam Team)
        {
            await _Teamrepository.NewTeam(Team);   
        }

        public async Task<bool> UpdateTeam(TmsTeam Team)
        {
            return await _Teamrepository.UpdateTeam(Team);   
        }
    }
}
