using System;
using System.Collections.Generic;

namespace Getty.Core.DTOs
{
    public partial class EmpEmployeeDTO
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; } = null!;
        public string EmpLastName { get; set; } = null!;
        public int EmpStsId { get; set; }
        public bool EmpStatus { get; set; }

    }
}
