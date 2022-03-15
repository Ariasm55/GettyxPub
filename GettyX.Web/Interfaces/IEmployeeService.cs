using Getty.Core.DTOs;
using GettyX.Web.Responses;

namespace GettyX.Web.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmpEmployeeDTO>> GetEmployees();
        void InsertEmployee(EmpEmployeeDTO employee);
        //Task<EmpEmployee> GetEmployee(int id);

        //Task NewEmployee(EmpEmployee Employee);

        //Task<bool> DeleteEmployee(int EmpID);

        //Task<bool> UpdateEmployee(EmpEmployee Employee);

    }
}