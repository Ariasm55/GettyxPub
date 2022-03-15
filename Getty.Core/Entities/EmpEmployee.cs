using System;
using System.Collections.Generic;

namespace Getty.Core.Entities
{
    public partial class EmpEmployee
    {
        public EmpEmployee()
        {
            UsrUsers = new HashSet<UsrUser>();
        }

        public int EmpId { get; set; }
        public string EmpFirstName { get; set; } = null!;
        public string EmpLastName { get; set; } = null!;
        public int EmpStsId { get; set; }
        public bool EmpStatus { get; set; }

        public virtual ICollection<UsrUser> UsrUsers { get; set; }
    }
}
