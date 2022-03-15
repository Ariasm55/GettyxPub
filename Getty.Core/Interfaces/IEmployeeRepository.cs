using Getty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmpEmployee>> GetEmployees();
        Task<EmpEmployee> GetEmployee(int id);

        Task NewEmployee(EmpEmployee Employee);

        Task<bool> DeleteEmployee(int EmpID);

        Task<bool> UpdateEmployee(EmpEmployee Employee);
    }
}
