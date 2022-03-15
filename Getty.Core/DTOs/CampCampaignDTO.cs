using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class CampCampaignDTO
    {
        
        public int CampId { get; set; }
        public string CampDescription { get; set; } = null!;
        public bool CampStatus { get; set; }
        public int CampStsId { get; set; }

    }
}
