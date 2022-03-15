using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class PnchPunchClock
    {
        public int PnchId { get; set; }
        public int PnchEmpId { get; set; }
        public DateTime PnchDate { get; set; }
        public string PnchDescrption { get; set; } = null!;
    }
}
