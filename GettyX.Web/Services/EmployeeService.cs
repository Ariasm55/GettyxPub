using Getty.Core.DTOs;
using GettyX.Web.Interfaces;
using GettyX.Web.Responses;
using System.Net.Http.Json;

namespace GettyX.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public async Task<EmpEmployee> GetEmployee(int id)
        //{
        //    return await _employeeRepository.GetEmployee(id);
        //}

        public async Task<List<EmpEmployeeDTO>> GetEmployees()
        {

            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<EmpEmployeeDTO>>>("/api/Employee/Employees");
            
            return response.Data;
        }

        public async void InsertEmployee(EmpEmployeeDTO employee)
        {
            if (employee.EmpId is 0) {

                 await _httpClient.PostAsJsonAsync("/api/Employee", employee);
            } 
            else
            {
                 await _httpClient.PutAsJsonAsync("/api/Employee", employee);
            }
            
        }



        //public async  Task NewEmployee(EmpEmployee Employee)
        //{ //Inserting employee information to employee table
        //    var empid = await _employeeRepository.NewEmployee(Employee);
        //    Employee.EmpId = empid;
        //    //Creaating default logins to User table
        //    await _UserRepository.NewUser(Employee);

           
        //}

        //public async Task<bool> UpdateEmployee(EmpEmployee Employee)
        //{
        //    return await _employeeRepository.UpdateEmployee(Employee);
        //}

        //public async Task<bool> DeleteEmployee(int EmpID)
        //{
        //    return await _employeeRepository.DeleteEmployee(EmpID);
        //}

    }
}
