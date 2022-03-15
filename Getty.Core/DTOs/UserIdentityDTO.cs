using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Core.DTOs
{
    public class UserIdentityDTO
    {
        public string UserName { get; set; }
        public string EmpID { get; set; }
        public List<string> Roles { get; set; }
    }
}
