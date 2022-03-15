using AutoMapper;
using Getty.Core.DTOs;
using Getty.Core.Entities;
using Getty.Core.Interfaces;
using GettyX.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GettyX.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]    
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeerepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeerepository, IMapper mapper)
        {
            _employeerepository = employeerepository;
            _mapper = mapper;
        }


        [HttpGet("Employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var _emps = await _employeerepository.GetEmployees();
            var _empsDTO = _mapper.Map<List<EmpEmployeeDTO>>(_emps);
            var response = new ApiResponse<List<EmpEmployeeDTO>>(_empsDTO);

            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {

            var _emp = await _employeerepository.GetEmployee(id);
            var _empDTO = _mapper.Map<EmpEmployeeDTO>(_emp);
            var response = new ApiResponse<EmpEmployeeDTO>(_empDTO);

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> NewEmployee(EmpEmployeeDTO _empDTO)
        {
            var _emp = _mapper.Map<EmpEmployee>(_empDTO);

            await _employeerepository.NewEmployee(_emp);

            _empDTO = _mapper.Map<EmpEmployeeDTO>(_emp);

            var response = new ApiResponse<EmpEmployeeDTO>(_empDTO);

            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmpEmployeeDTO EmployeeDto)
        {
            var _emp = _mapper.Map<EmpEmployee>(EmployeeDto);

            var result = await _employeerepository.UpdateEmployee(_emp);

            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }

        [HttpDelete("{EmpID}")]
        public async Task<IActionResult> DeleteEmployee(int EmpID)
        {
            var result = await _employeerepository.DeleteEmployee(EmpID);
            var response = new ApiResponse<bool>(result);

            return Ok(response);

        }


    }
}
