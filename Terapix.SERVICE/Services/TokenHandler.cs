using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Terapix.CORE.Models;
using Terapix.CORE.Services;
using Terapix.SERVICE.Extensions;

namespace Terapix.SERVICE.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration Configuration;
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string CreateRefreshToken()
        {
            byte[] number=new byte[32];
            using RandomNumberGenerator random=RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        public Token CreateToken(User user)
        {
            Token token = new Token();
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddDays(7);
            JwtSecurityToken jwtSecurityToken = new(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: token.Expiration,
                claims: SetClaims(user),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }
        public IEnumerable<Claim> SetClaims(User user)
        {
            Claim claim = new("sub",user.Id.ToString());
            List<Claim> claims = new List<Claim>(); 
            claims.Add(claim);
            claims.AddName(user.UserName);
            return claims;

        }
    }

}
