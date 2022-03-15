using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class CntCountryDTO
    {
        

        public int CntId { get; set; }
        public string CntDescription { get; set; } = null!;
        public bool CntStatus { get; set; }

    }
}
