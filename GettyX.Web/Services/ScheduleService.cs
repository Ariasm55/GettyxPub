using Getty.Core.DTOs;
using GettyX.Web.Interfaces;

namespace GettyX.Web.Services
{
    public class ScheduleService : IScheduleServices
    {
        public Task<List<SchdScheduleDayDTO>> GetScheduleDays()
        {
            throw new NotImplementedException();
        }

        public Task<List<SchScheduleDTO>> GetSchedules()
        {
            throw new NotImplementedException();
        }
    }
}
