using Getty.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettyX.Web.Interfaces
{
    public interface IUsersService
    {
        Task<bool> Authentication(UserLoginDTO usermuserModel);
        Task<bool> LogOut();
    }
}
