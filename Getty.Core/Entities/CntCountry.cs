using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class CntCountry
    {
        public CntCountry()
        {
            StsSites = new HashSet<StsSite>();
        }

        public int CntId { get; set; }
        public string CntDescription { get; set; } = null!;
        public bool CntStatus { get; set; }

        public virtual ICollection<StsSite> StsSites { get; set; }
    }
}
