using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class SchSchedule
    {
        public SchSchedule()
        {
            SchdScheduleDays = new HashSet<SchdScheduleDay>();
        }

        public int SchId { get; set; }
        public string SchDescription { get; set; } = null!;
        public string SchCode { get; set; } = null!;
        public bool SchStatus { get; set; }

        public virtual ICollection<SchdScheduleDay> SchdScheduleDays { get; set; }
    }
}
