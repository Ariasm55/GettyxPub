using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class UsrlUserRole
    {
        public int UsrlUsrId { get; set; }
        public int UsrlRlsId { get; set; }

        public virtual RlsRole UsrlRls { get; set; } = null!;
        public virtual UsrUser UsrlUsr { get; set; } = null!;
    }
}
