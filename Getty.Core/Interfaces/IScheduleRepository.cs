//using Getty.Core.Entities;
using Getty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Core.Interfaces
{
    public interface IScheduleRepository
    {
        Task<List<SchdScheduleDay>> GetSchedule(string user);
        Task<List<PnchPunchClock>> GetPunches(string user);
        void InsertPunch(PnchPunchClock punch);
        Task<List<SchSchedule>> GetSchedules();
        Task NewWeek(List<SchdScheduleDay> week);
        Task NewSchedule(SchSchedule schedule);

    }
}
