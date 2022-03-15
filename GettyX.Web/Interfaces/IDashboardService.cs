using Getty.Core.DTOs;

namespace GettyX.Web.Interfaces
{
    public interface IDashboardService
    {
        
        Task<List<SchdScheduleDayDTO>> GetCurrentSchedule(string user);
        Task<UserIdentityDTO> GetUsername();
        Task<List<PnchPunchClockDTO>> TodayPunches(string user);
        Task InsertPunch(PnchPunchClockDTO punch);
    }
}
