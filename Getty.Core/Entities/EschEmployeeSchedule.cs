using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class EschEmployeeSchedule
    {
        public int EschSchId { get; set; }
        public int EschEmpId { get; set; }

        public virtual EmpEmployee EschEmp { get; set; } = null!;
        public virtual SchSchedule EschSch { get; set; } = null!;
    }
}
