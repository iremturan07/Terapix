using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terapix.API.Filters;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;
using Terapix.CORE.Services;
using Terapix.SERVICE.Services;

namespace Terapix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : CustomBaseController
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var sessions = _sessionService.GetAll();
            var dtos = _mapper.Map<List<SessionDto>>(sessions).ToList();
            return CreateActionResult(CustomResponseDto<List<SessionDto>>.Success(200, dtos));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Session>))]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var session = await _sessionService.GetByIdAssync(id);
            var sessionDto = _mapper.Map<SessionDto>(session);
            return CreateActionResult(CustomResponseDto<SessionDto>.Success(200, sessionDto));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Session>))]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {

            var session = await _sessionService.GetByIdAssync(id);

            await _sessionService.RemoveAsync(session);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(SessionDto sessionDto)
        {

            var processedEntity = _mapper.Map<Session>(sessionDto);

            var session = await _sessionService.AddyAsync(processedEntity);

            var sessionResponseDto = _mapper.Map<SessionDto>(session);

            return CreateActionResult(CustomResponseDto<SessionDto>.Success(201, sessionDto));


        }
    }
}

