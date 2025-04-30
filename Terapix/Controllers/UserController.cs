using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terapix.API.Filters;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;
using Terapix.CORE.Services;
using Terapix.SERVICE.Hashing;

namespace Terapix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = _userService.GetAll();
            var dtos = _mapper.Map<List<UserDto>>(users).ToList();
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, dtos));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var user = await _userService.GetByIdAssync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {

            var user = await _userService.GetByIdAssync(id);

            await _userService.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
           

            var processedEntity = _mapper.Map<User>(userDto);

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePassword(userDto.Password, out passwordHash, out passwordSalt);

            processedEntity.PasswordHash = passwordHash;
            processedEntity.PasswordSalt = passwordSalt;

            var user = await _userService.AddyAsync(processedEntity);

            var userResponseDto = _mapper.Map<UserDto>(user);

            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, userDto));


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDTO)
        {
            Token token = await _userService.Login(userLoginDTO);
            if (token == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(401, "Bilgiler Uyuşmuyor"));

            }
            return CreateActionResult(CustomResponseDto<Token>.Success(200, token));
        }
    }
}
