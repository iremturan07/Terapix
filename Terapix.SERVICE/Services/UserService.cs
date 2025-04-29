using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;
using Terapix.CORE.Repositories;
using Terapix.CORE.Services;
using Terapix.CORE.UnitOfWorks;
using Terapix.SERVICE.Hashing;

namespace Terapix.SERVICE.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public UserService(
            IGenericRepository<User> repository,
            IUnitOfWorks unitOfWorks,
            ITokenHandler tokenHandler,
            IUserRepository userRepository) : base(repository, unitOfWorks)
        {
            _userRepository = userRepository;   
            _tokenHandler = tokenHandler;
        }
        public User GetByEmail(string email)
        {
            User user = _userRepository
                    .Where(u => u.Email == email)
                    .FirstOrDefault();

            return user;
        }
        public async Task<Token> Login(UserLoginDto userLoginDto)
        {
            Token token = new Token();
            var user = GetByEmail(userLoginDto.Email);
            if (user == null)
            {
                return null;
            }
            var result = false;
            result = HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt);


            if (result)
            {
               
                token = _tokenHandler.CreateToken(user);
                return token;
            }
            return null;
        }
    }


}
