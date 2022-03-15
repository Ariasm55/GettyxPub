using Getty.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Getty.Api.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {

            var emps = new EmployeeRepositoryFake().GetEmployees();

            return Ok(emps);
        }
    }
}
