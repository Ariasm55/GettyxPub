using Getty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task RegisterUser(UsrUser user);
        Task<bool> VerifyUser(string username, string password);
        List<string> GetUserRoles(string username);
        int GetEmpID(string username);
    }
}
