using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class SchdScheduleDayDTO
    {
        public int SchdDayId { get; set; }
        public DateTime? SchdStartTime { get; set; }
        public DateTime? SchdEndTime { get; set; }
        public int SchdNumberOfDay { get; set; }
        public string SchdDayDescription { get; set; } = null!;
        public int SchdScheduleId { get; set; }

    }
}
