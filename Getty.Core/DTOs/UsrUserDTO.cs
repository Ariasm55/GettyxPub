using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class UsrUserDTO
    {
        public int UsrId { get; set; }
        public string UsrUsername { get; set; } = null!;
        public string UsrPassword { get; set; } = null!;
        public int UsrRoleId { get; set; }
        public int UsrUuId { get; set; }
        public int UsrEmpId { get; set; }


    }
}
