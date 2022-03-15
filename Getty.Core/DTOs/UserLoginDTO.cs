using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Core.DTOs
{
    public class UserLoginDTO
    {
        public string UsrUsername { get; set; } = null!;
        public string UsrPassword { get; set; } = null!;
    }
}
