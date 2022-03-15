using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class UsrUser
    {
        public int UsrId { get; set; }
        public string UsrUsername { get; set; } = null!;
        public byte[] UsrSalt { get; set; } = null!;
        public byte[] UsrPassword { get; set; } = null!;
        public int UsrRoleId { get; set; }
        public int UsrUuId { get; set; }
        public int UsrEmpId { get; set; }

        public virtual EmpEmployee UsrEmp { get; set; } = null!;
    }
}
