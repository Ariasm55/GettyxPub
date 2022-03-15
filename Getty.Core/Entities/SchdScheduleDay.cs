using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class SchdScheduleDay
    {
        public int SchdDayId { get; set; }
        public DateTime SchdStartTime { get; set; }
        public DateTime SchdEndTime { get; set; }
        public int SchdNumberOfDay { get; set; }
        public string SchdDayDescription { get; set; } = null!;
        public int SchdScheduleId { get; set; }

        public virtual SchSchedule SchdSchedule { get; set; } = null!;
    }
}
