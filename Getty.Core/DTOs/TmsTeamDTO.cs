using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class TmsTeamDTO
    {
        public int TmsId { get; set; }
        public string TmsDescription { get; set; } = null!;
        public int TmsCampId { get; set; }

    }
}
