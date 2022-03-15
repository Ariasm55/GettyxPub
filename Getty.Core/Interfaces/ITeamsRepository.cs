using Getty.Core.Entities;

namespace Getty.Core.Interfaces
{
    public interface ITeamsRepository
    {
        Task<IEnumerable<TmsTeam>> GetTeams();
        Task<TmsTeam> GetTeam(int id);
        Task NewTeam(TmsTeam Team);
        Task<bool> DeleteTeam(int TeamID);
        Task<bool> UpdateTeam(TmsTeam Team);

    }
}
