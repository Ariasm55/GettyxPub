using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class PnchPunchClockDTO
    {
        public int PnchId { get; set; }
        public int PnchEmpId { get; set; }
        public DateTime PnchDate { get; set; }
        public string PnchDescrption { get; set; } = null!;
    }
}
