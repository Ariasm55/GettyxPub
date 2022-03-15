using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class TmmbTeamMember
    {
        public int TmmbEmpId { get; set; }
        public int TmmbTmsId { get; set; }

        public virtual EmpEmployee TmmbEmp { get; set; } = null!;
        public virtual TmsTeam TmmbTms { get; set; } = null!;
    }
}
