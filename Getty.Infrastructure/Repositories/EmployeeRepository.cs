using Getty.Core.Entities;
using Getty.Core.Interfaces;
using Getty.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Getty.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository


    {
        private readonly GettyContext _context;

        public EmployeeRepository(GettyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpEmployee>> GetEmployees()
        {
            var emps = await _context.EmpEmployees.ToListAsync();

            return emps;
        }

        public async Task<EmpEmployee> GetEmployee(int id)
        {
            var user = await _context.EmpEmployees.FirstOrDefaultAsync(x => x.EmpId == id && x.EmpStatus == true);

            return user;
        }

        public async Task NewEmployee(EmpEmployee Employee)
        {
            _context.EmpEmployees.Add(Employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployee(int EmpID)
        {
            var user = await GetEmployee(EmpID);
            _context.EmpEmployees.Remove(user) ;

            int rows = await _context.SaveChangesAsync();

            //return true if rows were affected
            return rows > 0;
        }


        public async Task<bool> UpdateEmployee(EmpEmployee Employee)
        {
            var currentEmployee = await GetEmployee(Employee.EmpId);
            currentEmployee.EmpFirstName = Employee.EmpFirstName;
            currentEmployee.EmpLastName = Employee.EmpLastName;
            currentEmployee.EmpStatus = Employee.EmpStatus;

            int rows = await _context.SaveChangesAsync();

            //return true if rows were affected
            return rows > 0;

        }

        //public async Task<EmpEmployee> UpdateEmployee(int EmpID, EmpEmployee Employee)
        //{
        //    var user = await _context.EmpEmployees.Where(x => x.EmpId == EmpID).FirstAsync();
        //    if (user != null)
        //    {
        //        user.EmpFirstName = Employee.EmpFirstName;
        //        user.EmpLastName = Employee.EmpLastName;
        //        user.EmpStsId = Employee.EmpStsId;

        //        _context.SaveChanges();

        //        return Employee;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


    }
}
