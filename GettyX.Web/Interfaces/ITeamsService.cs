using Getty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettyX.Web.Interfaces
{
    public interface ITeamsService
    {
        Task<IEnumerable<TmsTeam>> GetTeams();
        Task<TmsTeam> GetTeam(int id);
        Task NewTeam(TmsTeam Team);
        Task<bool> DeleteTeam(int TeamID);
        Task<bool> UpdateTeam(TmsTeam Team);
    }
}
