using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;

namespace Terapix.CORE.Services
{
    public interface IUserService:IService<User>
    {
        Task<Token> Login(UserLoginDto userLoginDTO);

    }
}
