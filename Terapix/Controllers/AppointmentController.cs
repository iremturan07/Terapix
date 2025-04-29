using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Terapix.API.Filters;
using Terapix.CORE.DTOs;
using Terapix.CORE.Models;
using Terapix.CORE.Services;

namespace Terapix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : CustomBaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;   
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var appointments = _appointmentService.GetAll();
            var dtos= _mapper.Map<List<AppointmentDto>>(appointments).ToList();
            return CreateActionResult(CustomResponseDto<List<AppointmentDto>>.Success(200, dtos));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Appointment>))]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {

            var appointment = await _appointmentService.GetByIdAssync(id);
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            return CreateActionResult(CustomResponseDto<AppointmentDto>.Success(200, appointmentDto));
        }
        [Authorize]
        [ServiceFilter(typeof(NotFoundFilter<Appointment>))]
        [HttpDelete("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            
            var appointment = await _appointmentService.GetByIdAssync(id);
            
            _appointmentService.ChangeStatus(appointment);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Save(AppointmentDto appointmentDto)
        {
            
            var processedEntity = _mapper.Map<Appointment>(appointmentDto);

            var appointment = await _appointmentService.AddyAsync(processedEntity);

            var appointmentResponseDto = _mapper.Map<AppointmentDto>(appointment);

            return CreateActionResult(CustomResponseDto<AppointmentDto>.Success(201, appointmentDto));


        }
    }
}
