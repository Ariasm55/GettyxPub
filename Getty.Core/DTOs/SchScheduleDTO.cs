using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class SchScheduleDTO
    {
      
        public int SchId { get; set; }
        public string SchDescription { get; set; } = null!;
        public string SchCode { get; set; } = null!;
        public bool SchStatus { get; set; }

    }
}
