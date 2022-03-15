//using Getty.Core.Entities;
using Getty.Core.Entities;
using Getty.Core.Interfaces;
using Getty.Infrastructure.Data;
//using Getty.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Getty.Infrastructure.Repositories
{
    public  class ScheduleRepository: IScheduleRepository
    {
        private readonly GettyContext _context;

        public ScheduleRepository(GettyContext context)
        {
            _context = context;
        }
        public void  InsertPunch(PnchPunchClock punch)
        {
            _context.PnchPunchClocks.Add(punch);
            _context.SaveChanges();             
            
        }

        public async Task<List<SchdScheduleDay>> GetSchedule(string user)
        {

            var Schedule = await (from sd in _context.SchdScheduleDays
                                    join sch in _context.SchSchedules
                                    on sd.SchdScheduleId equals sch.SchId
                                    join schemp in _context.EschEmployeeSchedules
                                    on sch.SchId equals schemp.EschSchId
                                    join us in _context.UsrUsers
                                    on schemp.EschEmpId equals us.UsrEmpId
                                    where us.UsrUsername == user 
                                    select new SchdScheduleDay
                                    {
                                        SchdStartTime = sd.SchdStartTime,
                                        SchdEndTime = sd.SchdEndTime,
                                        SchdNumberOfDay = sd.SchdNumberOfDay,
                                        SchdDayDescription = sd.SchdDayDescription
                                    }).ToListAsync();

            return Schedule;

        }

        public async Task<List<PnchPunchClock>> GetPunches(string user)
        {
            var today = DateTime.Today.Date;

            var punches = await (from pn in _context.PnchPunchClocks
                                 join emp in _context.EmpEmployees
                                 on pn.PnchEmpId equals emp.EmpId
                                 join us in _context.UsrUsers
                                 on emp.EmpId equals us.UsrEmpId
                                 where us.UsrUsername == user && pn.PnchDate.Date == today

                                 select new PnchPunchClock
                                 {
                                     PnchDate = pn.PnchDate,
                                     PnchDescrption = pn.PnchDescrption

                                 }).ToListAsync();

            return punches;
        }

        public async Task<List<SchSchedule>> GetSchedules()
        {
            return await _context.SchSchedules.ToListAsync();
        }

        public async Task NewWeek(List<SchdScheduleDay> week)
        {
            foreach (var day in week)
            {
                 _context.SchdScheduleDays.Add(day);
            }

            await _context.SaveChangesAsync();
           
        }

        public async Task NewSchedule(SchSchedule schedule)
        {
            _context.SchSchedules.Add(schedule);
            await _context.SaveChangesAsync();
        }
    }
}
