using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Terapix.CORE.Models;

namespace Terapix.CORE.Services
{
    public interface ITokenHandler
    {
        Token CreateToken(User user);  
        string CreateRefreshToken();  
        IEnumerable<Claim> SetClaims(User user); 
    }
}
