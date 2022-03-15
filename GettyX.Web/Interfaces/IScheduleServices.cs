using Getty.Core.DTOs;

namespace GettyX.Web.Interfaces
{
    public interface IScheduleServices
    {
        Task<List<SchScheduleDTO>> GetSchedules();

        Task<List<SchdScheduleDayDTO>> GetScheduleDays();
    }
}
