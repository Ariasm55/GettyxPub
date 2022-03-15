using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class TmsTeam
    {
        public int TmsId { get; set; }
        public string TmsDescription { get; set; } = null!;
        public int TmsCampId { get; set; }

        public virtual CampCampaign TmsCamp { get; set; } = null!;
    }
}
