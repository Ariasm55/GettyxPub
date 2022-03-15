using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Core.DTOs
{
    public class WeekScheduleDTO
    {
        public DateTime SchdStartTime { get; set; }
        public DateTime SchdEndTime { get; set; }
        public string SchdDayDescription { get; set; } = null!;
    }
}
