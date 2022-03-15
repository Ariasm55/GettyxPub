using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class CampCampaign
    {
        public CampCampaign()
        {
            TmsTeams = new HashSet<TmsTeam>();
        }

        public int CampId { get; set; }
        public string CampDescription { get; set; } = null!;
        public bool CampStatus { get; set; }
        public int CampStsId { get; set; }

        public virtual StsSite CampSts { get; set; } = null!;
        public virtual ICollection<TmsTeam> TmsTeams { get; set; }
    }
}
