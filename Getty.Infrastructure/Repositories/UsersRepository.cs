using Getty.Core.Entities;
using Getty.Core.Interfaces;
using Getty.Infrastructure.Data;
using Getty.Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Getty.Infrastructure.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly GettyContext _context;

        public UsersRepository(GettyContext context)
        {
            _context = context;
        }

    

        public async Task RegisterUser(UsrUser user)
        {
            _context.UsrUsers.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyUser(string username , string password)
        {
            var user = await _context.UsrUsers.FirstOrDefaultAsync(x => x.UsrUsername == username);
            
            if (user != null)  
            {
                if(!PasswordHasher.VerifyHash(password, user.UsrPassword, user.UsrSalt))
                {
                    return true;
                }
               
            }

            return true;
        }

        public List<string> GetUserRoles(string username)
        {
            var roles = (from r in _context.RlsRoles
                         join ur in _context.UsrlUserRoles
                         on r.RlsId equals ur.UsrlRlsId
                         join us in _context.UsrUsers
                         on ur.UsrlUsrId equals us.UsrId
                         where us.UsrUsername == username
                         select r.RlsDescription).ToList();

            return roles;

        }

        public  int GetEmpID(string username)
        {
            var EmpID =   (from u in _context.UsrUsers
                                 join em in _context.EmpEmployees
                                 on u.UsrEmpId equals em.EmpId
                                 where u.UsrUsername == username
                                 select u.UsrEmpId).First();

            return EmpID;
        }
    }
}
