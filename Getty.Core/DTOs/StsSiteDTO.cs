using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class StsSiteDTO
    {
      

        public int StsId { get; set; }
        public string StsName { get; set; } = null!;
        public int StsUtc { get; set; }
        public string StsDateFormat { get; set; } = null!;
        public int StsCntId { get; set; }
        public bool StsStatus { get; set; }

    }
}
