using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class StsSite
    {
        public StsSite()
        {
            CampCampaigns = new HashSet<CampCampaign>();
        }

        public int StsId { get; set; }
        public string StsName { get; set; } = null!;
        public int StsUtc { get; set; }
        public string StsDateFormat { get; set; } = null!;
        public int StsCntId { get; set; }
        public bool StsStatus { get; set; }

        public virtual CntCountry StsCnt { get; set; } = null!;
        public virtual ICollection<CampCampaign> CampCampaigns { get; set; }
    }
}
