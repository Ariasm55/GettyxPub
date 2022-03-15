using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class RlsRole
    {
        public int RlsId { get; set; }
        public string RlsDescription { get; set; } = null!;
        public bool RlsStatus { get; set; }
    }
}
